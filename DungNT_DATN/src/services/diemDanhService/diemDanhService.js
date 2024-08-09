import { baseService } from "../baseService";

export class DiemDanhService extends baseService {
  getDiemDanh = (ngay, username) => {
    return this.get(`DiemDanh/LayDiemDanh?ngay=${ngay}&username=${username}`);
  };

  addDiemDanh = (diemDanh) => {
    return this.post(`DiemDanh/ThemDiemDanh`, diemDanh);
  };

  getCaHoc = () => {
    return this.get(`CaHoc/LayToanBoCaHoc`);
  };

  suaDiemDanh = (diemDanh) => {
    return this.post(`DiemDanh/SuaDiemDanh`, diemDanh);
  };

  xoaDiemDanh = (diemDanhId) => {
    return this.post(`DiemDanh/XoaDiemDanh?diemDanhId=${diemDanhId}`);
  };

  LayLichDiemDanh = () => {
    return this.get(`DiemDanh/LayLichDiemDanh`);
  };
}

export const diemdanhservice = new DiemDanhService();
