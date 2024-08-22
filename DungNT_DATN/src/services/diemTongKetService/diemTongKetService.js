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
}

export const diemtongketservice = new DiemTongKetService();
