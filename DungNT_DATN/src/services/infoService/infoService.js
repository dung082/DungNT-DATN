import { baseService } from "../baseService";

export class InfoService extends baseService {
  getUserInfomation = (id) => {
    return this.get(`NguoiDung/LayThongTinNguoiDung?id=${id}`);
  };
}

export const infoservice = new InfoService()