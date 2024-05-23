import { Button, Input } from "antd";
import { useFormik } from "formik";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { loginservice } from "../../services/loginSerivce/loginService";

export default function Login() {
  const [statusMessage, setStatusMessage] = useState("");
  const navigate = useNavigate();
  const formik = useFormik({
    initialValues: {
      username: "",
      password: "",
    },
    validationSchema: Yup.object().shape({
      username: Yup.string()
        .required("Tên đăng nhập không được để trống")
        .nullable(),
      password: Yup.string()
        .required("Mật khẩu không được để trống")
        .nullable(),
    }),
    onSubmit: async (values) => {
      const user = {
        username: values.username,
        password: values.password,
      };

      try {
        const response = await loginservice.login(user);
        if (response.status === 200) {
          sessionStorage.setItem("userInfo", "dungnt");
          navigate("/");
        }
      } catch (err) {
        setStatusMessage("Tài khoản hoặc mật khẩu không chính xác");
      }
    },
  });

  return (
    <>
      <div
        className="h-screen w-screen"
        style={{
          background:
            "linear-gradient(#C6D7FF 100% , #F2EEFF 100% , #D2E0FF 100% , #E4DCFF 100%)",
        }}
      >
        <div
          className="w-[400px] bg-white absolute top-[50%] left-[50%] p-10 translate-x-[-50%] translate-y-[-50%] rounded-md"
          style={{ boxShadow: " 0px 0px 15px rgba(0, 0, 0, 0.16)" }}
        >
          <div>
            <h1 className="text-2xl text-center">ĐĂNG NHẬP</h1>
          </div>
          <div className="mt-4">
            <span className="font-bold">Tên đăng nhập</span>
          </div>
          <Input
            onChange={(e) => {
              formik.handleChange(e);
              setStatusMessage("");
            }}
            onBlur={(e) => {
              formik.handleBlur(e);
              setStatusMessage("");
            }}
            value={formik.values.username}
            name="username"
            className={
              formik.errors.username && formik.touched.username
                ? "border-red-600"
                : ""
            }
          />
          {formik.errors.username && formik.touched.username && (
            <span className="text-red-600">{formik.errors.username}</span>
          )}

          <div className="mt-4">
            <span className="font-bold">Mật khẩu</span>
          </div>
          <Input.Password
            onChange={(e) => {
              formik.handleChange(e);
              setStatusMessage("");
            }}
            onBlur={(e) => {
              formik.handleBlur(e);
              setStatusMessage("");
            }}
            value={formik.values.password}
            name="password"
            className={
              formik.errors.password && formik.touched.password
                ? "border-red-600"
                : ""
            }
          />
          {formik.errors.password && formik.touched.password && (
            <span className="text-red-600">{formik.errors.password}</span>
          )}
          <div>
            {" "}
            {statusMessage && (
              <span className="text-red-600"> {statusMessage}</span>
            )}
          </div>
          <Button
            className="mt-4 w-full"
            type="primary"
            onClick={() => formik.handleSubmit()}
          >
            Đăng nhập
          </Button>
        </div>
      </div>
    </>
  );
}
