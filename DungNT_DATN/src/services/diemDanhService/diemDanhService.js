import { baseService } from "../baseService";

export class DiemDanhService extends baseService {
    getDiemDanh = (ngay, username) => {
        return this.get(`DiemDanh/LayDiemDanh?ngay=${ngay}&username=${username}`)
    }

    addDiemDanh = (diemDanh) => {
        return this.post(`DiemDanh/ThemDiemDanh`, diemDanh)
    }

    getCaHoc = () => {
        return this.get(`CaHoc/LayToanBoCaHoc`)
    }

}

export const diemdanhservice = new DiemDanhService()