using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.PageContent;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.Dtos.PageContent;
using Entities.Enums;
using Entities.Enums.OperationClaim;

namespace Business.Concrete
{
    public class PageContentManager : IPageContentService
    {
        readonly IPageContentDal _pageContentDal;
        readonly IFileHelper _fileHelper;
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public PageContentManager(IPageContentDal pageContentDal, IFileHelper fileHelper, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _pageContentDal = pageContentDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [SecuredOperation(OperationClaimEnum.Admin, Priority = 1)]
        [ValidationAspect(typeof(PageContentUpdateDtoValidator), Priority = 2)]
        public async Task<DataResponse<string?>> Update(PageContentUpdateDto pageContentUpdateDto)
        {
            PageContent? pageContent = await _pageContentDal
                .GetByIdAsync(pageContentUpdateDto.Id);


            if (pageContent == null)
                throw new EntityNotFoundException("İçerik");


            bool onlyImageNeed = pageContentUpdateDto.Id switch
            {
                PageContentIds.HomeHero
                or PageContentIds.HomeMenuSection
                or PageContentIds.AboutHero
                or PageContentIds.AboutChefSection
                or PageContentIds.MenuHero
                or PageContentIds.GalleryHero
                or PageContentIds.ReservationHero
                => true,
                _ => false
            };


            if (onlyImageNeed)
                pageContentUpdateDto.Description = null;
            else
            {
                bool onlyDescriptionNeed = pageContentUpdateDto.Id switch
                {
                    PageContentIds.AboutFirstText
                    or PageContentIds.AboutSecondText => true,
                    _ => false
                };


                if (onlyDescriptionNeed)
                    pageContentUpdateDto.Image = null;
            }


            if (pageContentUpdateDto.Image != null)
            {
                ImageRespone imageRespone = await _fileHelper.Update(pageContentUpdateDto.Image!, pageContent.ImageName!);

                pageContent.ImagePath = imageRespone.Path;
                pageContent.ImageName = imageRespone.Name;
            }


            pageContent.Description = pageContentUpdateDto.Description ?? pageContent.Description;
            pageContent.UpdateDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return new DataResponse<string?>(pageContent.ImagePath ,CommonMessages.EntityUpdated);
        }



        public async Task<DataResponse<List<PageContentListDto>>> GetAll(PageEnum pageEnum)
        {
            List<PageContent> pageContents = await _pageContentDal
                .GetAllAsync(p => p.Page == pageEnum);


            if (pageContents.Count <= 0)
                throw new EntityNotFoundException("Sayfa");


            return new DataResponse<List<PageContentListDto>>(_mapper.Map<List<PageContentListDto>>(pageContents));
        }

    }
}
