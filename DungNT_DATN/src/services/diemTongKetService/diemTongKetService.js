import { baseService } from "../baseService";

export class DiemTongKetService extends baseService {
    getDiemTongKet = (username, kyHocId, monTongKetId) => {
        return this.get(`DiemTongKet/LayDiemTongKet?username=${username}&kyHocId=${kyHocId}&monTongKet=${monTongKetId}`);
    };

    getListMonTongKet = () => {
        return this.get(`MonTongKet/LayMonTongKet`);
    };

    getListKyHoc = (namHoc) => {
        return this.get(`KyHoc/LayKyHocTheoNam?namHoc=${namHoc}`);
    };
}

export const diemtongketservice = new DiemTongKetService();
