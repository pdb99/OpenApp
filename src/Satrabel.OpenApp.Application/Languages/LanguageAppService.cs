using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Satrabel.OpenApp.Authorization;

using Satrabel.OpenApp.Languages.Dto;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Abp.Authorization;
using Abp.IdentityFramework;
using Abp.Localization;

namespace Satrabel.OpenApp.Languages
{
    [AbpAuthorize(PermissionNames.Pages_Languages)]
    public class LanguageAppService : AsyncCrudAppService<ApplicationLanguage, LanguageDto, int, PagedResultRequestDto, LanguageDto, LanguageDto>, ILanguageAppService
    {
        private readonly ApplicationLanguageManager _languageManager;
        private ApplicationLanguage _defaultLanguage = null;

        public LanguageAppService(
            IRepository<ApplicationLanguage, int> repository,
            ApplicationLanguageManager languageManager)
            : base(repository)
        {
            _languageManager = languageManager;
            
        }
        public override async Task<LanguageDto> CreateAsync(LanguageDto input)
        {
            CheckCreatePermission();
            var language = ObjectMapper.Map<ApplicationLanguage>(input);
            language.TenantId = AbpSession.TenantId;
            await _languageManager.AddAsync(language);
            if (input.Default)
            {
                await _languageManager.SetDefaultLanguageAsync(AbpSession.TenantId, input.Name);
            }
            return MapToEntityDto(language);
        }
        public override async Task<LanguageDto> UpdateAsync(LanguageDto input)
        {
            CheckUpdatePermission();
            var language = MapToEntity(input);
            language.TenantId = AbpSession.TenantId;
            await _languageManager.UpdateAsync(AbpSession.TenantId, language);
            if (input.Default)
            {
                await _languageManager.SetDefaultLanguageAsync(AbpSession.TenantId, input.Name);
            }
            return await GetAsync(input);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var language = (await _languageManager.GetLanguagesAsync(AbpSession.TenantId)).FirstOrDefault(l => l.Id == input.Id);
            if (language == null)
            {
                return;
            }
            if (language.Name == "en")
            {
                throw new Abp.UI.UserFriendlyException("Can not delete 'en' language");
            }
            _defaultLanguage = await _languageManager.GetDefaultLanguageOrNullAsync(AbpSession.TenantId);
            if (language.Name == _defaultLanguage.Name)
            {
                throw new Abp.UI.UserFriendlyException("Can not delete default language");
            }
            await _languageManager.RemoveAsync(AbpSession.TenantId, language.Name);
        }

        public override async Task<LanguageDto> GetAsync(EntityDto<int> input)
        {
            _defaultLanguage = await _languageManager.GetDefaultLanguageOrNullAsync(AbpSession.TenantId);
            return await base.GetAsync(input);
        }

        public override async Task<PagedResultDto<LanguageDto>> GetAllAsync(PagedResultRequestDto input)
        {
            _defaultLanguage = await _languageManager.GetDefaultLanguageOrNullAsync(AbpSession.TenantId);
            var lst = await _languageManager.GetLanguagesAsync(AbpSession.TenantId);
            var query = lst.AsQueryable();

            var totalCount = query.Count();

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = query.ToList();

            return new PagedResultDto<LanguageDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
        protected override LanguageDto MapToEntityDto(ApplicationLanguage language)
        {
            var languageDto = base.MapToEntityDto(language);
            languageDto.Default = _defaultLanguage != null && language.Name == _defaultLanguage.Name;
            return languageDto;
        }
        protected override IQueryable<ApplicationLanguage> ApplySorting(IQueryable<ApplicationLanguage> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.Name);
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}