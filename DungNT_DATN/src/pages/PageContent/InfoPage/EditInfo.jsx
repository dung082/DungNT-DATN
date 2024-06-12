import { Button, DatePicker, Image, Input, Select, Upload } from "antd";
import dayjs from "dayjs";
import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import * as Yup from "yup";
import {
  danTocState,
  getListDanTocAction,
} from "../../../reducers/danTocReducer/danTocReducer";
import { closeDrawerAction } from "../../../reducers/drawerReducer/drawerReducer";
import {
  getUserInfomationAction,
  updateUserInfomationAction,
} from "../../../reducers/infoReducer/infoReducer";
import {
  getListTonGiaoAction,
  tonGiaoState,
} from "../../../reducers/tonGiaoReducer/tonGiaoReducer";
import { openWarning } from "../../../templates/notification";
import {
  getListKhoaHocAction,
  khoaHocState,
} from "../../../reducers/khoaHocReducer/khoaHocReducer";
const { Dragger } = Upload;
export default function EditInfo({ UserEdit }) {
  const dispatch = useDispatch();
  const { lstDanTocSelect } = useSelector(danTocState);
  const { listTonGiaoSelect } = useSelector(tonGiaoState);
  const { listKhoaHocSelect } = useSelector(khoaHocState);
  const [namSinhCha, setNamSinhCha] = useState(
    UserEdit.namSinhCha ? dayjs(UserEdit.namSinhCha) : dayjs()
  );
  const [namSinhMe, setNamSinhMe] = useState(
    UserEdit.namSinhMe ? dayjs(UserEdit.namSinhMe) : dayjs()
  );
  const [linkAvtar, setLinkAvatar] = useState(UserEdit.avatar);
  useEffect(() => {
    dispatch(getListDanTocAction());
    dispatch(getListTonGiaoAction());
    dispatch(getListKhoaHocAction());
  }, []);

  const refresh = () => {
    dispatch(getUserInfomationAction(UserEdit.id));
  };

  const formik = useFormik({
    initialValues: {
      id: UserEdit.id,
      username: UserEdit.username,
      status: UserEdit.status,
      hoTen: UserEdit.hoTen,
      ngaySinh: dayjs(UserEdit.ngaySinh),
      diaChi: UserEdit.diaChi,
      gioiTinh: UserEdit.gioiTinh,
      userType: UserEdit.userType,
      soDienThoai: UserEdit.soDienThoai,
      email: UserEdit.email,
      tonGiaoId: UserEdit.tonGiaoId,
      danTocId: UserEdit.danTocId,
      khoaHocId: UserEdit.khoaHocId,
      propeties: UserEdit.propeties,
      avatar: UserEdit.avatar,
      cccd: UserEdit.cccd,
      hoTenCha: UserEdit.hoTenCha,
      namSinhCha: UserEdit.namSinhCha,
      tonGiaoIdCha: UserEdit.tonGiaoIdCha,
      danTocIdCha: UserEdit.danTocIdCha,
      soDienThoaiCha: UserEdit.soDienThoaiCha,
      diaChiCha: UserEdit.diaChiCha,
      hoTenMe: UserEdit.hoTenMe,
      namSinhMe: UserEdit.namSinhMe,
      tonGiaoIdMe: UserEdit.tonGiaoIdMe,
      danTocIdMe: UserEdit.danTocIdMe,
      soDienThoaiMe: UserEdit.soDienThoaiMe,
      diaChiMe: UserEdit.diaChiMe,
    },
    validationSchema: Yup.object().shape({}),
    onSubmit: async (values) => {
      dispatch(updateUserInfomationAction(values, refresh));
    },
  });

  const onChangeDatePicker = (date, dateString) => {
    console.log(date, dateString);
  };

  const handleChangeImage = (info) => {
    if (info.file.status !== "uploading") {
      console.log(info.file, info.fileList);
    }
    if (info.file.status === "done") {
      formik.setFieldValue("avatar", info.file.response.value);
    } else if (info.file.status === "error") {
      openWarning("Thất bại", "Hệ thống lỗi không thể UpLoadFile");
    }
  };

  return (
    <>
      <div className="p-2">
        <span className="text-bold text-xl">THÔNG TIN CÁ NHÂN</span>
      </div>
      <div className="grid grid-cols-5">
        <div className="col-span-1 p-2">
          <Image
            width={120}
            height={180}
            src={formik.values.avatar}
            fallback="data:image/png;base64,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"
          />
        </div>
        <div className="col-span-4 p-2">
          <Dragger
            className="h-[180px]"
            name="file"
            maxCount={1}
            multiple={false}
            action={"http://localhost:7135/UploadImage"}
            onChange={(info) => handleChangeImage(info)}
          >
            <p>Nhấn hoặc kéo thả ảnh đại diện</p>
          </Dragger>
        </div>
      </div>
      <div className="grid grid-cols-2 mt-5">
        <div className="p-2">
          <span>Tên tài khoản</span>
          <Input value={formik.values.username} disabled name="username" />
        </div>

        <div className="p-2">
          <span>Họ và tên</span>
          <Input
            value={formik.values.hoTen}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            name="hoTen"
          />
        </div>

        <div className="p-2">
          <span>Ngày sinh</span>
          <DatePicker
            className="w-full"
            value={formik.values.ngaySinh}
            name="ngaySinh"
            onChange={(e) => {
              console.log(e);
              formik.setFieldValue("ngaySinh", dayjs(e));
            }}
            onBlur={formik.handleBlur}
          />
        </div>

        <div className="p-2">
          <span>Dân tộc</span>
          <Select
            className="w-full"
            options={lstDanTocSelect}
            value={formik.values.danTocId}
            onChange={(e) => {
              formik.setFieldValue("danTocId", e);
            }}
            onBlur={formik.handleBlur}
          />
        </div>

        <div className="p-2">
          <span>Giới tính</span>
          <Select
            className="w-full"
            value={formik.values.gioiTinh}
            onBlur={formik.handleBlur}
            onChange={(e) => {
              formik.setFieldValue("gioiTinh", e);
            }}
          >
            <Select.Option value={0}>Nam</Select.Option>
            <Select.Option value={1}>Nữ</Select.Option>
          </Select>
        </div>

        <div className="p-2">
          <span>Khóa học</span>
          <Select
            disabled
            className="w-full"
            options={listKhoaHocSelect}
            value={formik.values.khoaHocId}
            onChange={(e) => {
              formik.setFieldValue("khoaHocId", e);
            }}
            onBlur={formik.handleBlur}
          />
        </div>
        <div className="p-2">
          <span>Địa chỉ</span>
          <Input
            name="diaChi"
            value={formik.values.diaChi}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
        </div>

        <div className="p-2">
          <span>Số điện thoại</span>
          <Input
            name="soDienThoai"
            value={formik.values.soDienThoai}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
        </div>

        <div className="p-2">
          <span>Email </span>
          <Input
            name="email"
            value={formik.values.email}
            disabled
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
        </div>

        <div className="p-2">
          <span>Tôn giáo</span>
          <Select
            className="w-full"
            options={listTonGiaoSelect}
            value={formik.values.tonGiaoId}
            onChange={(e) => {
              formik.setFieldValue("tonGiaoId", e);
            }}
            onBlur={formik.handleBlur}
          />
        </div>
      </div>
      {UserEdit.userType === 2 && (
        <>
          <div className="p-2">
            <span className="text-bold text-xl">THÔNG TIN GIA ĐÌNH</span>
          </div>
          <div className="grid grid-cols-2">
            <div className="p-2">
              <span>Họ tên cha</span>
              <Input
                value={formik.values.hoTenCha}
                name="hoTenCha"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Năm sinh</span>
              <DatePicker
                className="w-full"
                picker="year"
                value={namSinhCha}
                id="namSinhCha"
                name="namSinhCha"
                onChange={(e) => {
                  setNamSinhCha(dayjs(e));
                  formik.setFieldValue("namSinhCha", dayjs(e).year());
                }}
                onBlur={formik.handleBlur}
              />
            </div>{" "}
            <div className="p-2">
              <span>Dân tộc</span>
              <Select
                className="w-full"
                options={lstDanTocSelect}
                id="danTocIdCha"
                value={formik.values.danTocIdCha}
                onChange={(e) => {
                  formik.setFieldValue("danTocIdCha", e);
                }}
                // onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Tôn giáo</span>
              <Select
                className="w-full"
                id="tonGiaoIdCha"
                options={listTonGiaoSelect}
                value={formik.values.tonGiaoIdCha}
                onChange={(e) => {
                  formik.setFieldValue("tonGiaoIdCha", e);
                }}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Địa chỉ</span>
              <Input
                name="diaChiCha"
                value={formik.values.diaChiCha}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Số điện thoại</span>
              <Input
                name="soDienThoaiCha"
                value={formik.values.soDienThoaiCha}
                id="soDienThoaiCha"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Họ tên mẹ</span>
              <Input
                value={formik.values.hoTenMe}
                name="hoTenMe"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Năm sinh</span>
              <DatePicker
                className="w-full"
                picker="year"
                id="namSinhMe"
                value={namSinhMe}
                name="namSinhMe"
                onChange={(e) => {
                  setNamSinhMe(dayjs(e));
                  formik.setFieldValue("namSinhMe", dayjs(e).year());
                }}
                // onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Dân tộc</span>
              <Select
                className="w-full"
                options={lstDanTocSelect}
                value={formik.values.danTocIdMe}
                onChange={(e) => {
                  formik.setFieldValue("danTocIdMe", e);
                }}
                id="danTocIdMe"
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Tôn giáo</span>
              <Select
                className="w-full"
                id="tonGiaoIdMe"
                options={listTonGiaoSelect}
                value={formik.values.tonGiaoIdMe}
                onChange={(e) => {
                  formik.setFieldValue("tonGiaoIdMe", e);
                }}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Địa chỉ</span>
              <Input
                name="diaChiMe"
                value={formik.values.diaChiMe}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
            </div>
            <div className="p-2">
              <span>Số điện thoại</span>
              <Input
                name="soDienThoaiMe"
                value={formik.values.soDienThoaiMe}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
            </div>
          </div>
        </>
      )}
      <div className="p-5 text-center">
        <Button type="default" onClick={() => dispatch(closeDrawerAction())}>
          Đóng
        </Button>
        <Button type="primary" className="ml-2" onClick={formik.handleSubmit}>
          Lưu thông tin
        </Button>
      </div>
    </>
  );
}
