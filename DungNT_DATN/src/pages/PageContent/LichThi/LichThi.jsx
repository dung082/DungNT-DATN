import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import { getLichThiAction, lichThiState, setChiTietLichThi } from "../../../reducers/lichThiReducer/lichThiReducer";
import dayjs from "dayjs";
import { DatePicker } from "antd";
import { openDrawerAction } from "../../../reducers/drawerReducer/drawerReducer";
import ChiTietLichThi from "./ChiTietLichThi";
import { openModalAction } from "../../../reducers/modalReducer/modalReducer";
export default function LichThi(props) {
  const dispatch = useDispatch();
  const { userInfo } = useSelector(globalState);
  const { lichThi } = useSelector(lichThiState);

  useEffect(() => {
    dispatch(getLichThiAction("", userInfo?.username));

    return () => {
      dispatch(setChiTietLichThi({}))
    }
  }, [])


  const openDetailLichThi = (lichThiId) => {
    dispatch(
      openModalAction({
        title: "Chi tiết lịch thi",
        ModalComponent: <ChiTietLichThi idLichThi={lichThiId} />,
        width: 1000
      })
    );
  }
  const [ngayHoc, setNgayHoc] = useState(dayjs());

  return <div>
    <div className="p-5">
      <div className=" bottem-border-title pb-2">
        <div className="flex justify-between">
          <div>
            <span className="font-bold text-xl">Lịch thi</span>
          </div>
        </div>
      </div>

      <div className="mt-2 flex items-start justify-end">
        <div className="ml-5">
          <div>
            <span>Chọn ngày học</span>
          </div>
          <DatePicker
            className="w-[200px] "
            value={ngayHoc}
            format={"DD/MM/YYYY"}
            onChange={(e) => {
              console.log(e)
              setNgayHoc(dayjs(e));
              dispatch(getLichThiAction(e.format('YYYY-MM-DD'), userInfo?.username));
            }}
            disabledDate={(current) => {
              return current && current > dayjs();
            }}
          />
        </div>
      </div>

      <div className="mt-4">
        <table className="w-full table-tkb">
          <tr>
            <th>Ca học</th>
            {lichThi?.ngay?.map((item) => {
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

            {lichThi?.data?.S?.map((item) => {
              if (item?.length === 0) {
                return (
                  <td key={Math.random() * 65165}>
                    <div title="Không có lịch thi " className="h-[200px] parent"></div>
                  </td>
                );
              } else {
                return (
                  <td
                    key={Math.random() * 65165}
                    title="Xem chi tiết lịch học"
                  >
                    {item?.map((item1) => {
                      return (
                        <div
                          onClick={() => {
                            openDetailLichThi(item1.id);
                          }}
                          key={Math.random() * 65165}
                          className="have-lichhoc parent flex items-center justify-center"
                          style={{ height: `calc(200px/${item.length})` }}
                        >
                          <div className="text-center">
                            <div>{item1?.tenMonThi}</div>
                            <div>{item1?.thoiGianBatDau}{" "}-{" "}{item1?.thoiGianKetThuc}</div>
                            <div>Phòng thi số {item1?.phongThi}</div>
                          </div>
                        </div>
                      );
                    })}
                  </td>
                );
              }
            })}

          </tr>

          <tr>
            <td>Ca chiều</td>
            {lichThi?.data?.C?.map((item, index) => {
              if (item?.length === 0) {
                return (
                  <td key={Math.random() * 65165}>
                    <div title="Không có lịch thi" className="h-[200px] parent"></div>
                  </td>
                );
              } else {
                return (
                  <td
                    key={Math.random() * 65165}
                    title="Xem chi tiết lịch học"
                  >
                    {item?.map((item1) => {
                      return (
                        <div
                          onClick={() => {
                            openDetailLichThi(item1.id);
                          }}
                          key={Math.random() * 65165}
                          className={`have-lichhoc parent flex items-center justify-center`}
                          style={{ height: `calc(200px/${item.length})` }}
                        >
                          <div className="text-center">
                            <div>{item1?.tenMonThi}</div>
                            <div>{item1?.thoiGianBatDau}{" "}-{" "}{item1?.thoiGianKetThuc}</div>
                            <div>Phòng thi số {item1?.phongThi}</div>
                          </div>
                        </div>
                      );
                    })}
                  </td>
                );
              }
            })}

          </tr>
        </table>
      </div>
    </div>
  </div>;
}
