import axios from "axios";
import { URLAPI } from "../templates/systemConfig";

export class baseService {
  get = async (url, data) => {
    return await axios({
      method: "GET",
      url: `${URLAPI}` + url,
      data: data,
    });
  };

  post = async (url, data) => {
    return await axios({
      method: "POST",
      url: `${URLAPI}` + url,
      data: data,
      header: {
        "Content-Type": "multipart/form-data",
      },
    });
  };
}