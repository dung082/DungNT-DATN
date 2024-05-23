import { baseService } from "../baseService";

export class LoginService extends baseService {
  login = (user) => {
    return this.post("TaiKhoan/Login", user);
  };
}

export const loginservice = new LoginService();
