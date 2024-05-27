import { notification } from "antd";

/*
 * Thành công !
 */
export const openNotification = (message, description) => {
  notification.success({
    message: <p className="text-uppercase font-weight-bold m-0">{message}</p>,
    description: <p className="m-0">{description}</p>,
    style: {
      border: "1px solid #28a745",
      background: "rgb(246,255,237)",
    },
  });
};

/*
 * Cảnh báo đỏ
 */
export const openWarning = (message, description) => {
  notification.error({
    message: <p className="text-uppercase font-weight-bold m-0">{message}</p>,
    description: <p className="m-0">{description}</p>,
    style: {
      border: "1px solid #dc3545",
      background: "rgb(255,242,240)",
    },
  });
};

/*
 * Information
 */
export const openInfo = (message, description) => {
  notification.info({
    message: <p className="text-uppercase font-weight-bold m-0">{message}</p>,
    description: <p className="m-0">{description}</p>,
    style: {
      border: "1px solid #17a2b8",
      background: "rgb(230,247,255)",
    },
  });
};