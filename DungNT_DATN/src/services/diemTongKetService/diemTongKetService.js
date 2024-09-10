import { baseService } from "../baseService";

export class DiemTongKetService extends baseService {
    getDiemTongKet = (type, username, kyHocId, monTongKetId) => {
        return this.get(`DiemTongKet/LayDiemTongKet?type=${type}&username=${username}&kyHocId=${kyHocId}&monTongKet=${monTongKetId}`);
    };

    getListMonTongKet = () => {
        return this.get(`MonTongKet/LayMonTongKet`);
    };

    getListKyHoc = (namHoc) => {
        return this.get(`KyHoc/LayKyHocTheoNam?namHoc=${namHoc}`);
    };

    addListDiemTongKet = (data) => {
        return this.post(`DiemTongKet/ThemListDiemTongKet`, data)
    }

    phucKhaoDiemTongKet = (username, namhoc, kyHocId, listMonTongKetId) => {
        return this.post(`DiemTongKet/PhucKhaoDiemTongKet?username=${username}&namHoc=${namhoc}&hocKyId=${kyHocId}`, listMonTongKetId)
    }

    layDiemTongKetTheoUser = (username, monTongKetId, kyHocId) => {
        return this.get(`DiemTongKet/LayDiemTongKetTheoUser?username=${username}&monTongKetId=${monTongKetId}&kyHocId=${kyHocId}`)
    }

    suaDiemTongKet = (type, diemTongKetId, diem) => {
        return this.post(`DiemTongKet/SuaDiemTongKet?type=${type}&diemTongKetId=${diemTongKetId}&diem=${diem}`)
    }
}

export const diemtongketservice = new DiemTongKetService();
