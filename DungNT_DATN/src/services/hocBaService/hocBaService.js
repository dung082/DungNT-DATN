import { baseService } from "../baseService";

export class HocBaService extends baseService {
    getHocBa = (username, lop) => {
        return this.get(`HocBa/LayHocBa?username=${username}&lop=${lop}`);
    };

    AddHocBa = (hocBaDto) => {
        return this.post(`HocBa/ThemHocBa`, hocBaDto)
    }
}

export const hocbaservice = new HocBaService();
