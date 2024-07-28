import { Button, DatePicker, Input, Popconfirm, Select } from "antd";
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import {
  diemDanhState,
  getListCaHocAction,
  xinNghiAction,
} from "../../../reducers/diemDanhReducer/diemDanhReducer";
import { closeModalAction } from "../../../reducers/modalReducer/modalReducer";
const { TextArea } = Input;

export default function DonXinNghiHoc(props) {
  const [ngayHoc, setNgayHoc] = useState(dayjs());
  const [caHoc, setCaHoc] = useState("");
  const [lyDo, setLyDo] = useState("");
  const { userInfo } = useSelector(globalState);
  const { listCaHoc } = useSelector(diemDanhState);
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(getListCaHocAction());
  }, []);
  const submitForm = () => {
    const data = {
      username: userInfo?.username,
      caHocId: caHoc,
      ngayHoc: ngayHoc.format("YYYY-MM-DD"),
      lyDo: lyDo,
      trangThai: 0,
    };

    dispatch(xinNghiAction(data));
  };
  return (
    <div className="py-3">
      <div className="mt-5">
        <div>
          {" "}
          <span>Ngày học</span>
        </div>

        <DatePicker
          format={"DD/MM/YYYY"}
          className="w-full"
          value={ngayHoc}
          onChange={(e) => {
            setNgayHoc(dayjs(e));
          }}
        />
      </div>

      <div className="mt-4">
        <div>
          {" "}
          <span>Ca học</span>
        </div>
        <Select
          className="w-full"
          value={caHoc}
          options={listCaHoc}
          onChange={(e) => setCaHoc(e)}
        />
      </div>

      <div className="mt-4">
        <div>
          {" "}
          <span>Lý do</span>
        </div>
        <TextArea
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

        <Popconfirm
          className="ml-3"
          title="Nộp đơn xin nghỉ"
          description="Bạn có chắc chắn muốn xin nghỉ?"
          onConfirm={submitForm}
          //   onCancel={cancel}
          okText="Nộp đơn"
          cancelText="hủy"
        >
          <Button type="primary">Gửi đơn</Button>
        </Popconfirm>
      </div>
    </div>
  );
}
