using System;
using AutoMapper;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    /// <summary>
    ///  
    ///     ViewModel => Model
    /// 
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile

    {
        //Provavelment Novo jeito de Mapear
        public DomainToViewModelMappingProfile()
        {

            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<EstabelecimentoViewModel, Estabelecimento>();
            CreateMap<VeiculoViewModel, Veiculos>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        //Old Way
        //protected override void Configure()
        //{
        //    Mapper.CreateMap<ClienteViewModel>, Cliente();
        //    Mapper.CreateMap<ProdutoViewModel>, Produto();
        //
        //}


    }
}