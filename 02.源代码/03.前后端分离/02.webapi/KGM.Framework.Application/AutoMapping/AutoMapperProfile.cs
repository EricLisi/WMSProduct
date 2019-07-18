using AutoMapper;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using static KGM.Framework.Domain.RoleEntity;

namespace KGM.Framework.Application.AutoMapping
{
    /// <summary>
    /// AutoMapper注册类
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AutoMapperProfile()
        {
            #region 平台注入
            CreateMap<PlatFormEntity, PlatFormSingleDto>();
            CreateMap<PlatFormInsertDto, PlatFormEntity>();
            #endregion

            #region  模块注入
            CreateMap<ModuleEntity, ModuleSingleDto>(); 
            CreateMap<ModuleSingleDto, ModuleEntity>();

            CreateMap<ModuleEntity.ButtonEntity, ModuleButtonSingleDto>();
            CreateMap<ModuleButtonSingleDto, ModuleEntity.ButtonEntity>();

            CreateMap<ModuleEntity.ColumnEntity, ModuleColumnSignleDto>();
            CreateMap<ModuleColumnSignleDto, ModuleEntity.ColumnEntity>();

            CreateMap<ModuleFormSingleDto, ModuleEntity.FormEntity>();
            CreateMap<ModuleEntity.FormEntity, ModuleFormSingleDto>();

            CreateMap<ModuleEntity, ModuleGridDto>();
            #endregion

            #region  用户注入
            CreateMap<UserEntity, UserSingleDto>();
            CreateMap<UserSingleDto, UserEntity>();
            #endregion

            #region  角色注入
            //角色菜单授权列注入
            CreateMap<RoleModuleEntity, RoleModuleSingleDto>();
            CreateMap<RoleModuleSingleDto, RoleModuleEntity>();


            //角色菜单按钮授权列注入
            CreateMap<RoleButtonEntity, RoleButtonSingleDto>();
            CreateMap<RoleButtonSingleDto, RoleButtonEntity>();

            //角色菜单列授权列注入
            CreateMap<RoleColumnEntity, RoleColumnSingleDto>();
            CreateMap<RoleColumnSingleDto, RoleColumnEntity>();

            ////角色菜单页面授权列注入
            //CreateMap<RoleModuleFormEntity, RoleModuleFormGetDto>();
            //CreateMap<RoleModuleFormGetDto, RoleModuleFormEntity>();

            CreateMap<RoleEntity, RoleSingleDto>();
            CreateMap<RoleSingleDto, RoleEntity>();
            #endregion

            #region  数据字典注入
            CreateMap<DictionaryEntity, DictionarySingleDto>();
            CreateMap<DictionarySingleDto, DictionaryEntity>();
            CreateMap<DictionaryEntity.DetailEntity, DictionaryDetailSingleDto>();
            CreateMap<DictionaryDetailSingleDto, DictionaryEntity.DetailEntity>();

            CreateMap<DictionaryDetailEntity, DictionaryDetailSingleDto>();
            CreateMap<DictionaryDetailSingleDto, DictionaryDetailEntity>();
            //CreateMap<DictionaryEntity, DictionaryGridsDto>();
            #endregion

            #region  客户注入
            CreateMap<CustomerEntity, CustomerSingleDto>();
            CreateMap<CustomerSingleDto, CustomerEntity>();
            CreateMap<CustomerEntity.OwnerEntity, CustomerOwnerSingleDto>();
            CreateMap<CustomerOwnerSingleDto, CustomerEntity.OwnerEntity>();
            #endregion

            #region 权属注入
            CreateMap<OwnerEntity, OwnerSingleDto>();
            CreateMap<OwnerSingleDto, OwnerEntity>();
            #endregion

            #region 公司注入
            CreateMap<CompanyEntity, CompanySingleDto>();
            CreateMap<CompanySingleDto, CompanyEntity>();

            CreateMap<CompanyEntity.DepartmentEntity, DepartmentSingleDto>();
            CreateMap<DepartmentSingleDto, CompanyEntity.DepartmentEntity>();
            #endregion

            #region 部门注入
            CreateMap<DepartmentEntity, DepartmentSingleDto>();
            CreateMap<DepartmentSingleDto, DepartmentEntity>();
            //    .ForMember(d => d.CompanyId, o => o.MapFrom(s => s.company.Id))
            //    .ForMember(d => d.CompanyCode, o => o.MapFrom(s => s.company.EnCode))
            //    .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.company.FullName));
            //CreateMap<DepartmentGetDto, DepartmentEntity>()
            //  .ForPath(d => d.company.Id, o => o.MapFrom(s => s.CompanyId))
            // .ForPath(d => d.company.EnCode, o => o.MapFrom(s => s.CompanyCode))
            // .ForPath(d => d.company.FullName, o => o.MapFrom(s => s.CompanyName));
            #endregion

            #region 区域注入
            CreateMap<AreaEntity, AreaSingleDto>();
            CreateMap<AreaSingleDto, AreaEntity>();
            #endregion

            #region 仓库注入
            CreateMap<WarehouseEntity, WarehouseSingleDto>();
            CreateMap<WarehouseSingleDto, WarehouseEntity>();

            CreateMap<WarehouseEntity.PositionEntity, PositionSingleDto>();
            CreateMap<PositionSingleDto, WarehouseEntity.PositionEntity>();
            #endregion

            #region 货位注入
            CreateMap<PositionEntity, PositionGetDto>();
            CreateMap<PositionGetDto, PositionEntity>();
            #endregion

            ////库存菜单注入
            //CreateMap<SRDetailEntity, SRDetailGetDto>();
            //CreateMap<SRDetailGetDto, SRDetailEntity>();

            ////库存菜单注入
            //CreateMap<SRMainEntity, SRMainGetDto>();
            //CreateMap<SRMainGetDto, SRMainEntity>();

            ////库存菜单注入
            //CreateMap<StockEntity, StockGetDto>();
            //CreateMap<StockGetDto, StockEntity>();

            ////出库通知单子表菜单注入
            //CreateMap<DPDetailEntity, DPDetailGetDto>();
            //CreateMap<DPDetailGetDto, DPDetailEntity>();

            ////出库通知单子表菜单注入
            //CreateMap<DPMainEntity, DPMainGetDto>();
            //CreateMap<DPMainGetDto, DPMainEntity>();


            ////入库通知单子表菜单注入
            //CreateMap<InStockNoticeBodyEntity, InStockNoticeBodyGetDto>();
            //CreateMap<InStockNoticeBodyGetDto, InStockNoticeBodyEntity>();

            ////入库通知单主表菜单注入
            //CreateMap<InStockNoticeHeadGetDto, InStockNoticeHeadEntity>();
            //CreateMap<InStockNoticeHeadEntity, InStockNoticeHeadGetDto>();


            ////商品类别菜单注入
            //CreateMap<InventoryClassEntity, InventoryClassGetDto>();
            //CreateMap<InventoryClassGetDto, InventoryClassEntity>();
            ////商品 菜单注入
            //CreateMap<InventoryEntity, InventoryGetDto>();
            //CreateMap<InventoryGetDto, InventoryEntity>();


            //条码规则菜单注入
            //CreateMap<BarCodeRuleMainEntity, BarCodeRuleMainSingleDto>();
            //CreateMap<BarCodeRuleMainSingleDto, BarCodeRuleMainEntity>();
            //CreateMap<BarCodeRuleMainEntity, BarCodeRuleGridDto>();

            ////货位菜单注入
            //CreateMap<PositionEntity, PositionGetDto>();
            //CreateMap<PositionGetDto, PositionEntity>();

            ////仓库菜单注入
            //CreateMap<WarehouseEntity, WarehouseGetDto>();
            //CreateMap<WarehouseGetDto, WarehouseEntity>();



            ////快递菜单注入
            //CreateMap<ExpCompanyEntity, ExpCompanyGetDto>();
            //CreateMap<ExpCompanyGetDto, ExpCompanyEntity>();

            ////权属菜单注入
            //CreateMap<OwnerEntity, OwnerGetDto>();
            //CreateMap<OwnerGetDto, OwnerEntity>();

            ////结算方式菜单注入
            //CreateMap<SaveWayEntity, SaveWayGetDto>();
            //CreateMap<SaveWayGetDto, SaveWayEntity>();

            ////收发类别菜单注入
            //CreateMap<ReceiveTypeEntity, ReceiveTypeGetDto>();
            //CreateMap<ReceiveTypeGetDto, ReceiveTypeEntity>();

            ////业务类型设置菜单注入
            //CreateMap<SetUpEntity, SetUpGetDto>();
            //CreateMap<SetUpGetDto, SetUpEntity>();



            ////用户注入
            //CreateMap<UserEntity, UserGetDto>();
            //CreateMap<UserGetDto, UserEntity>();

            ////角色注入
            //CreateMap<RoleEntity, RoleGetDto>();
            //CreateMap<RoleGetDto, RoleEntity>();




            ////平台注入
            //CreateMap<PlatFormEntity, PlatFormGetDto>();
            //CreateMap<PlatFormGetDto, PlatFormEntity>();
            ////权限注入
            //CreateMap<CompetenceEntity, CompetenceGetDto>();
            //CreateMap<CompetenceGetDto, CompetenceEntity>();
            ////岗位注入
            //CreateMap<PostEntity, PostGetDto>();
            //CreateMap<PostGetDto, PostEntity>();
            ////平台角色注入
            //CreateMap<RolePlatEntity, RolePlatGetDto>();
            //CreateMap<RolePlatGetDto, RolePlatEntity>();
            ////用户机构注入
            //CreateMap<UserCompanyEntity, UserCompanyGetDto>();
            //CreateMap<UserCompanyGetDto, UserCompanyEntity>();


            ////用户机构授权列注入
            //CreateMap<UserCompanyEntity, UserCompanyGetDto>();
            //CreateMap<UserCompanyGetDto, UserCompanyEntity>();

            ////用户部门授权列注入
            //CreateMap<UserDepartmentEntity, UserDepartmentGetDto>();
            //CreateMap<UserDepartmentGetDto, UserDepartmentEntity>();          




        }
    }
}
