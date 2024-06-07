import { baseService } from "../baseService";

export class KhoiService extends baseService {
  getAllKhoi = () => {
    return this.get(`Khoi/LayTatCaKhoi`);
  };
}

export const khoiservice = new KhoiService();
