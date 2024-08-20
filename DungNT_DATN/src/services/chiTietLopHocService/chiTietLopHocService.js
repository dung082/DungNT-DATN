import { baseService } from "../baseService";

export class ChiTietLopService extends baseService {
  getHSInClass = (username) => {
    return this.get(`ChiTietLopHoc/LayHocSinhTrongLop?username=${username}`);
  };

  getHSLopNamHoc = (namhoc, lopId) => {
    return this.get(`ChiTietLopHoc/LayHocSinhTrongLopById?namhoc=${namhoc}&lopId=${lopId}`);
  };
}

export const chitietlopservice = new ChiTietLopService();
