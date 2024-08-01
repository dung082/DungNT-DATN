import { baseService } from "../baseService";

export class ThongBaoService extends baseService {
    getThongBao = (username) => {
        return this.get(`ThongBao/LayThongBao?username=${username}`)
    }

    xacNhanDaXem = (thongBaoId) => {
        return this.post(`ThongBao/CapNhatTrangThai?thongBaoId=${thongBaoId}`)
    }

    xacNhanDaXemListThongBao = (listTbId) => {
        return this.post(`ThongBao/CapNhatTrangThaiListThongBao`, listTbId)
    }
}

export const thongbaoservice = new ThongBaoService();