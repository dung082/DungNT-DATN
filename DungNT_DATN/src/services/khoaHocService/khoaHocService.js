import { baseService } from "../baseService";

export class KhoaHocService extends baseService {
  getAllKhoaHoc = () => {
    return this.get(`KhoaHoc/LayTatCaKhoaHoc`);
  };
}

export const khoahocservice = new KhoaHocService();
