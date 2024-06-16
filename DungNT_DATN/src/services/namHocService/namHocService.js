import { baseService } from "../baseService";

export class NamHocService extends baseService {
  getAllNamHoc = () => {
    return this.get(`NamHoc/LayTatCaNamHoc`);
  };
}

export const namhocservice = new NamHocService();
