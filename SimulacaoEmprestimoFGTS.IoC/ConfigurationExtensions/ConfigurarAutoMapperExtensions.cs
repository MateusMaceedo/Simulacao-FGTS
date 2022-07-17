using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SimulacaoEmprestimoFGTS.Core.Dto.FGTS;
using SimulacaoEmprestimoFGTS.Core.Dto.SAC;
using SimulacaoEmprestimoFGTS.Domain.Model.FGTS;
using SimulacaoEmprestimoFGTS.Domain.Model.SAC;

namespace SimulacaoEmprestimoFGTS.IoC.ConfigurationExtensions
{
    public static class ConfigurarAutoMapperExtensions
    {
        public static void ConfigurarMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RepasseFGTS, RepasseFGTSDto>()
                .ForMember(x => x.Aliquota, source => source.MapFrom(src => src.Aliquota.Percentual))
                .ForMember(x => x.ParcelaAdicional, source => source.MapFrom(src => src.Aliquota.ParcelaAdicional));

                cfg.CreateMap<SimulacaoFGTS, SimulacaoFGTSDto>()
                .ForMember(x => x.ValorRepasseFGTS, opt => opt.MapFrom(src => src.Repasse.ValorParcela))
                .ForMember(x => x.DataVencimento, opt => opt.MapFrom(src => src.Repasse.DataVencimento));

                cfg.CreateMap<SimulacaoSAC, SimulacaoSACDto>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
