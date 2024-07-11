import { baseService } from "../baseService";

export class ThoiKhoaBieuService extends baseService {
    getThoiKhoaBieu = (ngayhoc, username) => {
        return this.get(`ThoiKhoaBieu/LayThoiKhoaBieu?ngayHoc=${ngayhoc}&username=${username}`);
    };
}

export const thoikhoabieuservice = new ThoiKhoaBieuService();
