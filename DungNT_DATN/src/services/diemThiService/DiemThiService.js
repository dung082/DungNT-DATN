import { baseService } from "../baseService";

export class DiemThiService extends baseService {
    getDiemThi = (type, username, kythiid) => {
        return this.get(`DiemThi/LayDiemThi?type=${type}&username=${username}&kyThiId=${kythiid}`);
    };

    addDiemThi = (diemthi) => {
        return this.post(`DiemThi/ThemDiemThi`,diemthi);
    };
}

export const diemthiservice = new DiemThiService();
