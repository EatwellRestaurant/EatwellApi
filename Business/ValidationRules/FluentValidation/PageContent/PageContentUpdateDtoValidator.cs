using Business.Constants.Paths;
using Entities.Concrete;
using Entities.Constants;
using Entities.Dtos.PageContent;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.PageContent
{
    public class PageContentUpdateDtoValidator : AbstractValidator<PageContentUpdateDto>
    {
        public PageContentUpdateDtoValidator()
        {
            RuleFor(p => p).Custom((dto, context) =>
            {
                string? message = GetImagePathErrorMessage(dto.Id, dto.Image);


                if (message is not null)
                    context.AddFailure(nameof(dto.Image), message);
            }); 
            
            
            
            RuleFor(p => p).Custom((dto, context) =>
            {
                string? message = GetDescriptionErrorMessage(dto.Id, dto.Description);
                

                if (message is not null)
                    context.AddFailure(nameof(dto.Description), message);
            });


        }

        private string? GetDescriptionErrorMessage(int id, string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return id switch
                {
                    PageContentIds.HomeAboutSection =>
                        "Anasayfa hakkımda bölümü için açıklama metni zorunludur.",

                    PageContentIds.AboutFirstText =>
                        "Hakkımda sayfasının ilk metin alanı zorunludur.",
                    
                    PageContentIds.AboutSecondText =>
                        "Hakkımda sayfasının ikinci metin alanı zorunludur.",

                    _ => null
                };
            }

            return null;
        } 

        private string? GetImagePathErrorMessage(int id, IFormFile? imagePath)
        {
            if (imagePath is null)
            {
                return id switch
                {
                    PageContentIds.HomeHero =>
                        "Anasayfa hero bölümü için görsel zorunludur.",

                    PageContentIds.HomeAboutSection =>
                        "Anasayfa hakkımda bölümü için görsel zorunludur.",

                    PageContentIds.HomeMenuSection => 
                        "Anasayfa menü bölümü için görsel zorunludur.",

                    PageContentIds.AboutHero => 
                        "Hakkımda hero bölümü için görsel zorunludur.",

                    PageContentIds.AboutChefSection =>
                        "Hakkımda şef bölümü için görsel zorunludur.",

                    PageContentIds.MenuHero =>
                        "Menü hero bölümü için görsel zorunludur.",

                    PageContentIds.GalleryHero =>
                        "Galeri hero bölümü için görsel zorunludur.",

                    PageContentIds.ReservationHero =>
                        "Rezervasyon hero bölümü için görsel zorunludur.",

                    _ => null
                };
            }

            return null;
        }
    }
}
