import { baseService } from "../baseService";

export class DiemThiService extends baseService {
    getDiemThi = ( username, kythiid , monThiId) => {
        return this.get(`DiemThi/LayDiemThi?username=${username}&kyThiId=${kythiid}&monThiId=${monThiId}`);
    };

    addDiemThi = (diemthi) => {
        return this.post(`DiemThi/ThemDiemThi`,diemthi);
    };

    getListMonThi = (lopId) => {
        return this.get(`MonThi/LayMonThi?lopId=${lopId}`);
    };
}

export const diemthiservice = new DiemThiService();
