import { baseService } from "../baseService";

export class InfoService extends baseService {
  getUserInfomation = (id) => {
    return this.get(`NguoiDung/LayThongTinNguoiDung?id=${id}`);
  };

  updateUserInfomation = (user) => {
    return this.post(`NguoiDung/SuaNguoiDung`, user);
  };
}

export const infoservice = new InfoService();
