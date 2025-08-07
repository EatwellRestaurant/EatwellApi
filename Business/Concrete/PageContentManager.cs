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

namespace Business.Concrete
{
    public class PageContentManager : IPageContentService
    {
        readonly IPageContentDal _pageContentDal;
        readonly IFileHelper _fileHelper;
        readonly IUnitOfWork _unitOfWork;

        public PageContentManager(IPageContentDal pageContentDal, IFileHelper fileHelper, IUnitOfWork unitOfWork)
        {
            _pageContentDal = pageContentDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(PageContentDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> Save(PageContentDto pageContentDto)
        {
            PageContent? pageContent = await _pageContentDal.GetByIdAsync(pageContentDto.Id);

            if (pageContent == null)
                throw new EntityNotFoundException("İçerik");


            bool onlyImageNeed = pageContentDto.Id switch
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
            {
                pageContentDto.Description = null;

                ImageRespone imageRespone = await _fileHelper.Update(pageContentDto.ImagePath!, pageContent.ImageName!);
                
                pageContent.ImagePath = imageRespone.Path;
                pageContent.ImageName = imageRespone.Name;
            }


            bool onlyDescriptionNeed = pageContentDto.Id switch
            {
                PageContentIds.AboutFirstText
                or PageContentIds.AboutSecondText => true,
                _ => false
            };


            if (onlyDescriptionNeed)
                pageContentDto.ImagePath = null;
            

            pageContent.Description = pageContentDto.Description;
            pageContent.UpdateDate = DateTime.Now;


            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
        }

    }
}
