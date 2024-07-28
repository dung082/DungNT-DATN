import { baseService } from "../baseService";

export class ThoiKhoaBieuService extends baseService {
    getThoiKhoaBieu = (type ,ngayhoc, username) => {
        return this.get(`ThoiKhoaBieu/LayThoiKhoaBieu?type=${type}&ngayHoc=${ngayhoc}&username=${username}`);
    };

    getChiTietThoiKhoaBieu = (tkbId) => {
        return this.get(`ThoiKhoaBieu/ChiTietThoiKhoaBieu?tkbId=${tkbId}`);
    };
}

export const thoikhoabieuservice = new ThoiKhoaBieuService();
