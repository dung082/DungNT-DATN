import { baseService } from "../baseService";

export class TonGiaoService extends baseService {
  getAllTonGiao = () => {
    return this.get(`TonGiao/LayToanBoTonGiao`);
  };
}

export const tongiaoservice = new TonGiaoService();
