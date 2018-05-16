using architecture.Entity;
using architecture.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace architecture.Web.Mapping
{
    public class DomainToViewModelMappingProfile : Profile 
    {   
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }
        public DomainToViewModelMappingProfile()
        {
            ConfigureMappings();
        }


        /// <summary>
        /// Creates a mapping between source (Domain) and destination (ViewModel)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<Person, PersonVIewModel>().ReverseMap();

        }
     
    }
    public class NullStringConverter : ITypeConverter<string, string>
    {
        public string Convert(string source, ResolutionContext context)
        {
            return source ?? string.Empty;
        }
        public string Convert(string source, string destination, ResolutionContext context)
        {
            return source ?? string.Empty;
        }

    }
}