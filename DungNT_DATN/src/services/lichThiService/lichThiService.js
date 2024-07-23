import { baseService } from "../baseService";

export class LichThiService extends baseService {
    getLichThi = (ngayThi, username) => {
        return this.get(`LichThi/LayLichThi?ngayThi=${ngayThi}&username=${username}`)
    }

    getDetailLichThi = (lichThiId, username) => {
        return this.get(`LichThi/ChiTietLichThi?lichThiId=${lichThiId}&username=${username}`)
    }
}

export const lichthiservice = new LichThiService()