import { baseService } from "../baseService";

export class QuanLyHocSinhService extends baseService {
  getAllNamHoc = () => {
    return this.get(`NamHoc/LayTatCaNamHoc`);
  };
}

export const quanlyhocsinhservice = new QuanLyHocSinhService();
