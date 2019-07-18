import request from '@/utils/request'


export function getTabData(token) {
    return [{
        F_Id:"1",
        F_EnCode:"01",
        F_FullName:"入库管理",
        F_Icon:"fa-sign-in"
    },{
        F_Id:"2",
        F_EnCode:"02",
        F_FullName:"出库管理",
        F_Icon:"fa-sign-out"
    },{
        F_Id:"3",
        F_EnCode:"03",
        F_FullName:"库内管理",
        F_Icon:"fa-home"
    }]
}
