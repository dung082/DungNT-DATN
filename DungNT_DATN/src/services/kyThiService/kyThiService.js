import { baseService } from "../baseService";

export class KyThiService extends baseService {
  getKyThiTheoNam = (namHoc) => {
    return this.get(`KyThi/LayKyThiTheoNam?namhoc=${namHoc}`);
  };
}

export const kythiservice = new KyThiService();
