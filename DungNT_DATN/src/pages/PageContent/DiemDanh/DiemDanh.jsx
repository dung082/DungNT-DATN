import { useDispatch, useSelector } from "react-redux";
import {
  diemDanhState,
  getDiemDanhAction,
} from "../../../reducers/diemDanhReducer/diemDanhReducer";
import { useEffect, useState } from "react";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import dayjs from "dayjs";
import { Button, DatePicker, Input, Modal, Select } from "antd";
import { openModalAction } from "../../../reducers/modalReducer/modalReducer";
import DonXinNghiHoc from "./DonXinNghiHoc";
import ChiTietDiemDanh from "./ChiTietDiemDanh";

export default function DiemDanh(props) {
  const dispatch = useDispatch();
  const { diemDanh } = useSelector(diemDanhState);
  const { userInfo } = useSelector(globalState);
  const [ngay, setNgay] = useState(dayjs());

  useEffect(() => {
    dispatch(getDiemDanhAction("", userInfo?.username));
  }, []);

  return (
    <>
      <div>
        <div className="p-5">
          <div className=" bottem-border-title pb-2">
            <div className="flex justify-between">
              <div>
                <span className="font-bold text-xl">Điểm danh, xin nghỉ</span>
              </div>
            </div>
          </div>
          <div className="mt-4">
            <div className="flex justify-end items-end">
              <div className="flex items-end">
                <div className="ml-2">
                  <Button type="primary" onClick={() => {
                    let ngaytk = dayjs(ngay).add(-7, 'day')
                    setNgay(ngaytk);
                    dispatch(
                      getDiemDanhAction(
                        ngaytk.format("YYYY-MM-DD"),
                        userInfo?.username
                      )
                    );
                  }}>Tuần trước</Button>
                </div>
                <div className="ml-2">
                  <div>
                    <span>Chọn ngày học</span>
                  </div>
                  <DatePicker
                    allowClear={false}
                    className="w-[200px] "
                    value={ngay}
                    format={"DD/MM/YYYY"}
                    onChange={(e) => {
                      setNgay(dayjs(e));
                      dispatch(
                        getDiemDanhAction(
                          e.format("YYYY-MM-DD"),
                          userInfo?.username
                        )
                      );
                    }}
                    disabledDate={(current) => {
                      return current && current > dayjs();
                    }}
                  />
                </div>
                <div className="ml-2">
                  <Button type="primary" onClick={() => {
                    let ngaytk = dayjs(ngay).add(7, 'day')
                    setNgay(ngaytk);
                    dispatch(
                      getDiemDanhAction(
                        ngaytk.format("YYYY-MM-DD"),
                        userInfo?.username
                      )
                    );
                  }}>Tuần trước</Button>
                </div>
              </div>

              <Button
                type="primary"
                className="ml-3"
                onClick={() => {
                  dispatch(
                    openModalAction({
                      title: "Đơn xin nghỉ học",
                      ModalComponent: <DonXinNghiHoc />,
                    })
                  );
                }}
              >
                Xin nghỉ
              </Button>
            </div>
            <table className="w-full table-tkb mt-4">
              <tr>
                <th>Ca học</th>
                {diemDanh?.ngay?.map((item) => {
                  return (
                    <th key={Math.random() * 65165}>
                      <div>
                        <div>
                          {dayjs(item).day() === 0
                            ? "Chủ nhật"
                            : `Thứ ${dayjs(item).day() + 1}`}
                        </div>
                        <div>
                          <span>{dayjs(item).format("DD/MM/YYYY")}</span>
                        </div>
                      </div>
                    </th>
                  );
                })}
              </tr>
              <tr>
                <td>Ca sáng</td>

                {diemDanh?.dd?.S?.map((item) => {
                  if (item === null) {
                    return (
                      <td key={Math.random() * 65165}>
                        <div
                          className="parent flex justify-center items-center"
                          style={{ height: 100 }}
                        >
                          {" "}
                        </div>
                      </td>
                    );
                  } else {
                    return (
                      <td
                        key={Math.random() * 65165}
                        title="Xem chi tiết lịch học"
                      >
                        <div
                          className="parent flex justify-center items-center"
                          style={{ height: 100 }}
                          onClick={() => {
                            dispatch(
                              openModalAction({
                                title: "Chi tiết điểm danh",
                                ModalComponent: (
                                  <ChiTietDiemDanh DiemDanh={item} />
                                ),
                              })
                            );
                          }}
                        >
                          {item?.trangThai === 1 ? (
                            <span className="material-icons text-xl font-bold text-success">
                              done
                            </span>
                          ) : item?.trangThai === 0 ? (
                            <span className="text-xl font-bold text-pendding">
                              ...
                            </span>
                          ) : item?.trangThai === 2 ? (
                            <span className="text-xl font-bold">-</span>
                          ) : (
                            <span className="material-icons text-xl font-bold text-error">
                              close
                            </span>
                          )}
                        </div>
                      </td>
                    );
                  }
                })}
              </tr>

              <tr>
                <td>Ca chiều</td>

                {diemDanh?.dd?.C?.map((item) => {
                  if (item === null) {
                    return (
                      <td key={Math.random() * 65165}>
                        <div
                          className="parent flex justify-center items-center"
                          style={{ height: 100 }}
                        >
                          {" "}
                        </div>
                      </td>
                    );
                  } else {
                    return (
                      <td
                        key={Math.random() * 65165}
                        title="Xem chi tiết lịch học"
                      >
                        <div
                          className="parent flex justify-center items-center"
                          style={{ height: 100 }}
                        >
                          {item?.trangThai === 1 ? (
                            <span className="material-icons text-xl font-bold text-success">
                              done
                            </span>
                          ) : item?.trangThai === 0 ? (
                            <span className="text-xl font-bold text-pendding">
                              ...
                            </span>
                          ) : item?.trangThai === 2 ? (
                            <span className="text-xl font-bold">-</span>
                          ) : (
                            <span className="material-icons text-xl font-bold text-error">
                              close
                            </span>
                          )}
                        </div>
                      </td>
                    );
                  }
                })}
              </tr>
            </table>

            <div className="mt-5 flex justify-start items-center">
              <span className="description-tableDiemDanh text-center"></span>{" "}
              <span className="ml-2"> Không có lịch học</span>
              <span className="description-tableDiemDanh ml-5 text-center">
                <span className="material-icons text-success">done</span>
              </span>{" "}
              <span className="ml-2"> Có mặt</span>
              <span className="description-tableDiemDanh ml-5 text-center">
                <span className=" text-pendding">...</span>
              </span>{" "}
              <span className="ml-2"> Đang chờ duyệt</span>
              <span className="description-tableDiemDanh ml-5 text-center">
                -
              </span>{" "}
              <span className="ml-2"> Nghỉ có phép</span>
              <span className="description-tableDiemDanh ml-5 text-center">
                <span className="material-icons text-error">close</span>
              </span>{" "}
              <span className="ml-2">Nghỉ không phép</span>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
