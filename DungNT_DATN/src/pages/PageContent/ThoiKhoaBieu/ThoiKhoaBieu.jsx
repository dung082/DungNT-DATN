import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getThoiKhoaBieuAction,
  setThoiKhoaBieu,
  thoiKhoaBieuState,
} from "../../../reducers/thoiKhoaBieuReducer/thoiKhoaBieuReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import dayjs from "dayjs";
import { forEach } from "lodash";
import { DatePicker } from "antd";
import { openDrawerAction } from "../../../reducers/drawerReducer/drawerReducer";
import ChiTietThoiKhoaBieu from "./ChiTietThoiKhoaBieu";

export default function ThoiKhoaBieu(props) {
  const dispatch = useDispatch();
  const { userInfo } = useSelector(globalState);
  const { thoiKhoaBieu } = useSelector(thoiKhoaBieuState);
  useEffect(() => {
    dispatch(getThoiKhoaBieuAction(ngayHoc, userInfo?.username));

    return () => {
      dispatch(setThoiKhoaBieu({}))
    }
  }, []);

  const [ngayHoc, setNgayHoc] = useState(dayjs());

  const renderTkbThieu = (soluongthieu) => {
    const divs = [];
    for (let i = 0; i < soluongthieu; i++) {
      divs.push(
        <div key={Math.random() * 123312} title="Không có lịch học" className="parent"></div>
      );
    }
    return divs;
  };

  const openDetailThoiKhoaBieu = (id) => {
    dispatch(
      openDrawerAction({
        title: "Chi tiết tiết học",
        DrawerComponent: <ChiTietThoiKhoaBieu idTietHoc={id} />,
      })
    );
  };
  return (
    <>
      <div>
        <div className="p-5">
          <div className=" bottem-border-title pb-2">
            <div className="flex justify-between">
              <div>
                <span className="font-bold text-xl">Thời khóa biểu</span>
              </div>
            </div>
          </div>
          <div className="mt-2 flex items-start justify-end">
            <div className=" w-[200px]">
              <div>
                <span>Lớp</span>
              </div>
              <div>
                <span className="font-bold">
                  {thoiKhoaBieu?.lopObj?.tenLop
                    ? thoiKhoaBieu?.lopObj?.tenLop
                    : "Đang không trong lớp nào"}
                </span>
              </div>
            </div>

            <div className="ml-5 w-[300px]">
              <div>
                <span>Kỳ học</span>
              </div>
              <div>
                <span className="font-bold">
                  {thoiKhoaBieu?.kyhoc
                    ? thoiKhoaBieu?.kyhoc?.tenKyHoc
                    : "Đang không trong khoảng kỳ học nào"}
                </span>
              </div>
            </div>

            <div className="ml-5 w-[200px]">
              <div>
                <span>Năm học</span>
              </div>
              <div>
                <span className="font-bold">{thoiKhoaBieu?.namHoc}</span>
              </div>
            </div>

            <div className="ml-5">
              <div>
                <span>Chọn ngày học</span>
              </div>
              <DatePicker
                className="w-[200px] "
                value={ngayHoc}
                format={"DD/MM/YYYY"}
                onChange={(e) => {
                  setNgayHoc(dayjs(e));
                  dispatch(getThoiKhoaBieuAction(e.format('YYYY-MM-DD'), userInfo?.username));
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
                {thoiKhoaBieu?.ngay?.map((item) => {
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

                {thoiKhoaBieu?.data?.S?.map((item) => {
                  if (item?.length === 0) {
                    return (
                      <td key={Math.random() * 65165}>
                        <div title="Không có lịch học" className="parent" ></div>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                      </td>
                    );
                  } else if (item?.length < 5 && item?.length > 0) {
                    let conlai = 5 - item?.length;
                    return (
                      <td key={Math.random() * 65165}>
                        {item?.map((item1) => {
                          return (
                            <div
                              onClick={() => {
                                openDetailThoiKhoaBieu(item1.id);
                              }}
                              className="have-lichhoc parent"
                              key={Math.random() * 65165}
                              title="Xem chi tiết lịch học"
                            >
                              {item1?.tenMonHoc +
                                " - " +
                                item1?.tenGiaoVien.toString()?.split(" ")[
                                item1?.tenGiaoVien.toString().split(" ")
                                  ?.length - 1
                                ]}
                            </div>
                          );
                        })}

                        {renderTkbThieu(conlai)}
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
                                openDetailThoiKhoaBieu(item1.id);
                              }}
                              key={Math.random() * 65165}
                              className="have-lichhoc parent"
                            >
                              {item1?.tenMonHoc +
                                " - " +
                                item1?.tenGiaoVien.toString()?.split(" ")[
                                item1?.tenGiaoVien.toString().split(" ")
                                  ?.length - 1
                                ]}
                            </div>
                          );
                        })}
                      </td>
                    );
                  }
                })}
                {/* <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td> */}
              </tr>

              <tr>
                <td>Ca chiều</td>
                {thoiKhoaBieu?.data?.C?.map((item, index) => {
                  if (item?.length === 0) {
                    return (
                      <td key={Math.random() * 65165}>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                        <div title="Không có lịch học" className="parent"></div>
                      </td>
                    );
                  } else if (item?.length < 5 && item?.length > 0) {
                    let conlai = 5 - item?.length;
                    return (
                      <td
                        key={Math.random() * 65165}
                        title="Xem chi tiết lịch học"
                      >
                        {item?.map((item1) => {
                          return (
                            <div
                              onClick={() => {
                                openDetailThoiKhoaBieu(item1.id);
                              }}
                              key={Math.random() * 65165}
                              className="have-lichhoc parent"
                            >
                              {item1?.tenMonHoc +
                                " - " +
                                item1?.tenGiaoVien.toString()?.split(" ")[
                                item1?.tenGiaoVien.toString().split(" ")
                                  ?.length - 1
                                ]}
                            </div>
                          );
                        })}

                        {renderTkbThieu(conlai)}
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
                                openDetailThoiKhoaBieu(item1.id);
                              }}
                              key={Math.random() * 65165}
                              className="have-lichhoc parent"
                            >
                              {item1?.tenMonHoc +
                                " - " +
                                item1?.tenGiaoVien.toString()?.split(" ")[
                                item1?.tenGiaoVien.toString().split(" ")
                                  ?.length - 1
                                ]}
                            </div>
                          );
                        })}
                      </td>
                    );
                  }
                })}
                {/* <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td>
                            <td>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                                <div>1</div>
                            </td> */}
              </tr>
            </table>
          </div>
        </div>
      </div>
    </>
  );
}
