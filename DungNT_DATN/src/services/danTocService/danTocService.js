import { baseService } from "../baseService";

export class DanTocService extends baseService {
  getAllDanToc = () => {
    return this.get(`DanToc/LayToanBoDanToc`);
  };
}

export const dantocservice = new DanTocService();
