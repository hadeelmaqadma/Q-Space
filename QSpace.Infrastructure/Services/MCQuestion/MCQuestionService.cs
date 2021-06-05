using AutoMapper;
using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using QSpace.Infrastructure.Services.Files;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.MCQuestion
{
    public class MCQuestionService : IMCQuestionService
    {
        private readonly QSpaceDbContext _DB;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public MCQuestionService(QSpaceDbContext DB, IMapper mapper, IFileService fileService)
        {
            _DB = DB;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task Create(CreateMCQuestionDto dto) {
            var mcq = _mapper.Map<MCQuestionDbEntity>(dto);
            if (dto.AttachmentURL != null)
            {
                mcq.AttachmentURL = await _fileService.SaveFile(dto.AttachmentURL, "Attachments");
                await _DB.MCQustions.AddAsync(mcq);
            }
            else
                _DB.MCQustions.Add(mcq);
            _DB.SaveChanges();
        }
        public async Task Update(UpdateMCQuestionDto dto) {
            var mcq = _DB.MCQustions.Find(dto.Id);
            if (mcq != null) {
                var UpdatedMcq = _mapper.Map<UpdateMCQuestionDto, MCQuestionDbEntity>(dto, mcq);
                if (dto.AttachmentURL != null)
                {
                    mcq.AttachmentURL = await _fileService.SaveFile(dto.AttachmentURL, "Attachments");                    
                }
            }
            _DB.MCQustions.Update(mcq);
            _DB.SaveChanges();
        }
        public void ChangeActive(int Id)
        {
            var mcq = _DB.MCQustions.Find(Id);
            if (mcq == null)
            {
                throw new Exception();
            }
            else
            {
                mcq.IsActive = !mcq.IsActive;
                _DB.MCQustions.Update(mcq);
                _DB.SaveChanges();
            }
        }
        public bool Delete(int Id)
        {
            var mcq = _DB.MCQustions.Find(Id);
            if (mcq != null)
            {
                mcq.IsDeleted = true;
                _DB.MCQustions.Update(mcq);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }  
        
        public MCQuestionViewModel GetById(int id)
        {
            var mcq = _DB.MCQustions.Find(id);
            if (mcq == null) return null;

            var mcqVM = _mapper.Map<MCQuestionViewModel>(mcq);

            return mcqVM; 

        }
        
    }
}