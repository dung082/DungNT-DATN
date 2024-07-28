import { Button, DatePicker, Input, Popconfirm, Select } from "antd";
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import {
  diemDanhState,
  getListCaHocAction,
  suaDiemDanhAction,
  xinNghiAction,
  xoaDiemDanhAction,
} from "../../../reducers/diemDanhReducer/diemDanhReducer";
import { closeModalAction } from "../../../reducers/modalReducer/modalReducer";
const { TextArea } = Input;

export default function ChiTietDiemDanh(props) {
  const [ngayHoc, setNgayHoc] = useState(dayjs(props?.DiemDanh?.ngayHoc));
  const [caHoc, setCaHoc] = useState(props?.DiemDanh?.caHocId);
  const [trangThai, setTrangThai] = useState(props?.DiemDanh?.trangThai);
  const [lyDo, setLyDo] = useState(props?.DiemDanh?.lyDo);
  const { userInfo } = useSelector(globalState);
  const { listCaHoc } = useSelector(diemDanhState);
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(getListCaHocAction());
  }, []);
  const submitForm = () => {
    const data = {
      id: props?.DiemDanh?.id,
      username: userInfo?.username,
      caHocId: caHoc,
      ngayHoc: ngayHoc.format("YYYY-MM-DD"),
      lyDo: lyDo,
      trangThai: props?.DiemDanh?.trangThai,
    };

    dispatch(suaDiemDanhAction(data));
  };

  const listSelectTrangThai = [
    {
      label: "Đang chờ duyệt",
      value: 0,
    },
    {
      label: "Có mặt",
      value: 1,
    },
    {
      label: "Nghỉ có phép",
      value: 2,
    },
    {
      label: "Nghỉ không phép",
      value: 3,
    },
  ];
  return (
    <div className="py-3">
      <div className="mt-5">
        <div>
          {" "}
          <span>Ngày học</span>
        </div>

        <DatePicker
          disabled
          format={"DD/MM/YYYY"}
          className="w-full"
          value={ngayHoc}
          //   onChange={(e) => {
          //     setNgayHoc(dayjs(e));
          //   }}
        />
      </div>

      <div className="mt-4">
        <div>
          {" "}
          <span>Ca học</span>
        </div>
        <Select
          disabled
          className="w-full"
          value={caHoc}
          options={listCaHoc}
          //   onChange={(e) => setCaHoc(e)}
        />
      </div>

      <div className="mt-4">
        <div>
          {" "}
          <span>Trạng thái</span>
        </div>
        <Select
          disabled
          className="w-full"
          value={trangThai}
          options={listSelectTrangThai}
          //   onChange={(e) => setCaHoc(e)}
        />
      </div>

      <div className="mt-4">
        <div>
          {" "}
          <span>Lý do</span>
        </div>
        <TextArea
          disabled={trangThai !== 0}
          className="w-full"
          rows={4}
          value={lyDo}
          onChange={(e) => setLyDo(e.target.value)}
        />
      </div>

      <div className="mt-5 text-center">
        <Button
          type="default"
          onClick={() => {
            dispatch(closeModalAction());
          }}
        >
          Đóng
        </Button>

        {dayjs() >= dayjs(ngayHoc) ? (
          <></>
        ) : (
          <Popconfirm
            className="ml-3"
            title="Nộp đơn xin nghỉ"
            description="Bạn có chắc chắn hủy đơn xin nghỉ?"
            onConfirm={() => {
              dispatch(
                xoaDiemDanhAction(props?.DiemDanh?.id, userInfo?.username)
              );
            }}
            //   onCancel={cancel}
            okText="Hủy nộp đơn"
            cancelText="hủy"
          >
            <Button
              className="ml-3"
              disabled={dayjs() >= dayjs(ngayHoc)}
              type="primary"
              danger
            >
              Hủy đơn nghỉ học
            </Button>
          </Popconfirm>
        )}

        <Popconfirm
          className="ml-3"
          title="Nộp đơn xin nghỉ"
          description="Bạn có chắc chắn sửa đơn xin nghỉ?"
          onConfirm={submitForm}
          //   onCancel={cancel}
          okText="Sửa đơn"
          cancelText="hủy"
        >
          <Button
            disabled={trangThai !== 0 || dayjs() >= dayjs(ngayHoc)}
            type="primary"
          >
            Cập nhật đơn
          </Button>
        </Popconfirm>
      </div>
    </div>
  );
}
