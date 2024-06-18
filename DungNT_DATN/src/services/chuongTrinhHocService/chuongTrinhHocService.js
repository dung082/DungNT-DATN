import { baseService } from "../baseService";

export class ChuongTrinhHocService extends baseService {
  getChuongTrinhHoc = () => {
    return this.get(`MonHoc/LayTatCaMonHoc`);
  };

  getChuongTrinhHocTheoKhoi = (KhoiId) => {
    return this.get(`MonHoc/LayMonHocTheoKhoi?Khoi=${KhoiId}`);
  };
}

export const chuongtrinhhocservice = new ChuongTrinhHocService();
