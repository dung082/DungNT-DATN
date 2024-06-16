import { baseService } from "../baseService";

export class ChiTietLopService extends baseService {
  getHSInClass = (username) => {
    return this.get(`ChiTietLopHoc/LayHocSinhTrongLop?username=${username}`);
  };
}

export const chitietlopservice = new ChiTietLopService();
