import { baseService } from "../baseService";

export class LopService extends baseService {
    getAllLop = () => {
        return this.get(`Lop/LayTatCaLop`);
    };
}

export const lopservice = new LopService();
