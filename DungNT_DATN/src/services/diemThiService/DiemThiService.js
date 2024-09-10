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
        return this.post(`DiemThi/ThemListDiemThi`, listDiemThi)
    }

    phucKhaoDiemThi = (username, namhoc, kyThiId, listMonThiId) => {
        return this.post(`DiemThi/PhucKhaoDiemThi?username=${username}&namHoc=${namhoc}&kyThiId=${kyThiId}`, listMonThiId)
    }

    getMonThiByUser = (username, namhoc) => {
        return this.get(`MonThi/LayMonThiTheoUser?username=${username}&namhoc=${namhoc}`)
    }

    layDiemThiTheoUser = (username, monThiId, kyThiId) => {
        return this.get(`DiemThi/LayDiemThiTheoUser?username=${username}&monThiId=${monThiId}&kyThiId=${kyThiId}`)
    }

    suaDiemThi = (type, diemThiId, diem) => {
        return this.post(`DiemThi/SuaDiemThi?type=${type}&diemThiId=${diemThiId}&diem=${diem}`)
    }
}

export const diemthiservice = new DiemThiService();
