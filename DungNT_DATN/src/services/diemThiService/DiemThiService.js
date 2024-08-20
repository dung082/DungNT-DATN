import { baseService } from "../baseService";

export class DiemThiService extends baseService {
    getDiemThi = (type, username, kythiid, monThiId) => {
        return this.get(`DiemThi/LayDiemThi?type=${type}&username=${username}&kyThiId=${kythiid}&monThiId=${monThiId}`);
    };

    addDiemThi = (diemthi) => {
        return this.post(`DiemThi/ThemDiemThi`, diemthi);
    };

    getListMonThi = (lopId) => {
        return this.get(`MonThi/LayMonThi?lopId=${lopId}`);
    };

    themListDiemThi = (listDiemThi) => {
        this.post(`DiemThi/ThemListDiemThi`, listDiemThi)
    }
}

export const diemthiservice = new DiemThiService();
