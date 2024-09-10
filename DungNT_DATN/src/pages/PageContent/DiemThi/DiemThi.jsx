import { Button, Select } from "antd";
import React, { useEffect, useState } from "react";
import { Bar, Doughnut } from "react-chartjs-2";
import { useDispatch, useSelector } from "react-redux";
import {
  diemThiState,
  getDiemThiAction,
  getListMonThiAction,
  setKyThi,
  setMonThi,
  setNamHoc,
  setTypeSearch,
} from "../../../reducers/diemThiReducer/diemThiReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import {
  getListKyThiAction,
  kyThiState,
} from "../../../reducers/kyThiReducer/kyThiReducer";
import TableComponent from "../../../assets/Component/TableComponent";
import { DIEM_THI_COLUMN_CONFIG } from "../../../templates/tableConfig";
import { openModalAction } from "../../../reducers/modalReducer/modalReducer";
import PhucKhaoDiemThi from "./PhucKhaoDiemThi";
export default function DiemThi(props) {
  const dispatch = useDispatch();
  const { userInfo } = useSelector(globalState);
  const {
    diemThi,
    pageNumber,
    pageSize,
    typeSearch,
    kyThi,
    namHoc,
    errorMessage,
    listMonThi,
    monThi,
  } = useSelector(diemThiState);
  const { listKyThi } = useSelector(kyThiState);
  const [mt, setMt] = useState("");
  const [type, setType] = useState(0);
  const listTypeSearch = [
    {
      label: "Bảng thống kê",
      value: 0,
    },
    {
      label: "Biểu đồ phân tích",
      value: 1,
    },
  ];
  const checkDiemThiTK = (diemTK, xeptheo, soHocSinh) => {
    if (diemTK >= 0 && diemTK < 4) {
      return (
        <span>
          Bạn đạt loại <span className="font-bold">Kém.</span> Và có{" "}
          <span className="font-bold">{soHocSinh[4] - 1}</span> học sinh trong{" "}
          {xeptheo} đạt loại giống bạn
        </span>
      );
    } else if (diemTK >= 4 && diemTK < 5.5) {
      return (
        <span>
          Bạn đạt loại <span className="font-bold">Yếu.</span> Và có{" "}
          <span className="font-bold">{soHocSinh[3] - 1}</span> học sinh trong{" "}
          {xeptheo} đạt loại giống bạn
        </span>
      );
    } else if (diemTK >= 5.5 && diemTK < 7) {
      return (
        <span>
          Bạn đạt loại <span className="font-bold">Trung bình.</span> Và có{" "}
          <span className="font-bold">{soHocSinh[2] - 1}</span> học sinh trong{" "}
          {xeptheo} đạt loại giống bạn
        </span>
      );
    } else if (diemTK >= 7 && diemTK < 8.5) {
      return (
        <span>
          Bạn đạt loại <span className="font-bold">Khá.</span> Và có{" "}
          <span className="font-bold">{soHocSinh[1] - 1}</span> học sinh trong{" "}
          {xeptheo} đạt loại giống bạn
        </span>
      );
    } else if (diemTK >= 8.5 && diemTK < 10) {
      return (
        <span>
          Bạn đạt loại <span className="font-bold">Giỏi.</span> Và có{" "}
          <span className="font-bold">{soHocSinh[0] - 1}</span> học sinh trong{" "}
          {xeptheo} đạt loại giống bạn
        </span>
      );
    } else {
      return (
        <span className="font-bold">
          Điểm thi của bạn không thể xếp hạng do quá ảo
        </span>
      );
    }
  };
  const listNamHoc = [
    {
      label: "2022-2023",
      value: "2022-2023",
    },
    {
      label: "2023-2024",
      value: "2023-2024",
    },
    {
      label: "2024-2025",
      value: "2024-2025",
    },
  ];

  useEffect(() => {

    dispatch(getDiemThiAction(0, userInfo?.username, "", ""));
    dispatch(getListMonThiAction(userInfo?.lopIdHienTai));
    return () => {
      dispatch(setTypeSearch(0));
    };
  }, []);

  const phucKhao = () => {
    dispatch(openModalAction({
      title: "Phúc khảo điểm thi",
      ModalComponent: <PhucKhaoDiemThi />
    }))
  }

  return (
    <div>
      <div className="p-5">
        <div className=" bottem-border-title pb-2">
          <div className="flex justify-between">
            <div>
              <span className="font-bold text-xl">Xem điểm thi</span>
            </div>
          </div>
        </div>
        <div className="flex items-end justify-center">
          <div className="w-[1100px] flex">
            <div className="p-2">
              <span>Xem theo</span>
              <Select
                placeholder="Chọn phương thức xem"
                className="w-full"
                options={listTypeSearch}
                value={type}
                onChange={(e) => {
                  setType(e);
                  setMt("");
                }}
              // value={namHocSelect}
              />
            </div>

            <div className="p-2">
              <span>Năm học</span>
              <Select
                placeholder="Chọn kỳ học"
                className="w-full"
                options={listNamHoc}
                value={namHoc}
                onChange={(e) => {
                  dispatch(setNamHoc(e));
                  dispatch(getListKyThiAction(e));
                  dispatch(setKyThi(null));
                }}
              // value={namHocSelect}
              />
            </div>

            <div className="p-2">
              <span>Kỳ thi</span>
              <Select
                placeholder="Chọn kỳ thi"
                className="w-full"
                options={listKyThi}
                value={kyThi}
                onChange={(e) => {
                  dispatch(setKyThi(e));
                }}
              />
            </div>

            <div className="p-2">
              <span>Môn thi</span>
              <Select
                disabled={!type}
                className="w-full"
                placeholder="Chọn môn thi"
                options={listMonThi}
                value={mt}
                onChange={(e) => {
                  setMt(e);
                }}
              />
            </div>

            <div className="p-2 flex items-end">
              <Button
                type="primary"
                onClick={() => {
                  dispatch(setMonThi(mt));
                  dispatch(
                    getDiemThiAction(type, userInfo?.username, kyThi, mt)
                  );
                }}
              >
                Tra cứu
              </Button>
            </div>
            <div className="p-2 flex items-end">
              <Button
                type="primary"
                onClick={phucKhao}
              >
                Phúc khảo điểm
              </Button>
            </div>
          </div>
        </div>

        <div className="mt-4 py-5 border-b border-[#b6b5b5]">
          <div className="">
            <span className="font-bold text-xl">Thông tin học sinh</span>
          </div>

          <div className="grid grid-cols-4 mt-2">
            <div className="">
              <span>
                <span className="font-bold">Họ và tên: </span> {userInfo?.hoTen}
              </span>
            </div>
            <div className="">
              <span>
                <span className="font-bold">Lớp: </span> {diemThi?.lop?.tenLop}
              </span>
            </div>
            <div className="">
              <span>
                <span className="font-bold">Kỳ thi: </span>{" "}
                {diemThi?.kyThi?.tenKyThi}
              </span>
            </div>
            <div className="">
              <span>
                <span className="font-bold">Năm học: </span>{" "}
                {diemThi?.kyHoc?.namHoc}
              </span>
            </div>

          </div>
        </div>

        {typeSearch === 0 ? (
          <div>
            <div className="mt-4">
              <div className="">
                <span className="font-bold text-xl">Điểm thi của học sinh</span>
              </div>
            </div>
            <div className="mt-3">
              <TableComponent
                className="mt-3"
                ColumnConfig={DIEM_THI_COLUMN_CONFIG}
                DataSource={diemThi?.listDT}
                CurrentPage={1}
                CurrentPageSize={10}
                ShowSizeChanger={false}
                hidePagination={true}
              />
            </div>
          </div>
        ) : (
          <div>
            <div className="mt-4">
              <div className="">
                <span className="font-bold text-xl">
                  Biểu đồ phân tích kết quả thi
                </span>
              </div>
            </div>
            {!diemThi?.messageError ? (
              monThi === "" ? (
                <div className="grid grid-cols-2 mt-3">
                  <div>
                    <div className="text-center">
                      Điểm trung bình các môn thi của bạn là :{" "}
                      <span className="font-bold">{diemThi?.diemTbMon}</span>
                    </div>
                    <div className="text-center">
                      {checkDiemThiTK(
                        diemThi?.diemTbMon,
                        "lớp",
                        diemThi?.slDiemThiLop
                      )}
                    </div>
                    <div>
                      <Doughnut
                        className="m-auto w-[400px] h-[400px] mt-3"
                        data={{
                          labels: diemThi?.slDiemThiLop?.map((value, index) => {
                            const labelName = [
                              "Giỏi",
                              "Khá",
                              "Trung Bình",
                              "Yếu",
                              "Kém",
                            ][index];
                            const percentage = (
                              (value /
                                diemThi?.slDiemThiLop?.reduce(
                                  (a, b) => a + b,
                                  0
                                )) *
                              100
                            ).toFixed(2);
                            return `${labelName} : ${value} học sinh (${percentage}%)`;
                          }),

                          datasets: [
                            {
                              label: "Số học sinh",
                              backgroundColor: [
                                "#3e95cd",
                                "#8e5ea2",
                                "#3cba9f",
                                "#e8c3b9",
                                "#c45850",
                              ],
                              data: diemThi?.slDiemThiLop,
                            },
                          ],
                        }}
                        options={{
                          plugins: {
                            title: {
                              display: true,
                              text: "Điểm thi trung bình môn của học sinh theo lớp",
                            },
                            legend: {
                              display: true,
                              position: "bottom", // Hiển thị legend ở bên phải
                              align: "start", // Căn lề trái cho legend
                              labels: {
                                usePointStyle: true, // Sử dụng hình tròn nhỏ làm marker
                                padding: 20, // Khoảng cách giữa các dòng
                                generateLabels: function (chart) {
                                  const labels = chart.data.labels;
                                  const datasets = chart.data.datasets;
                                  return labels?.map((label, index) => ({
                                    text: label,
                                    fillStyle:
                                      datasets[0].backgroundColor[index],
                                  }));
                                },
                              },
                            },
                            datalabels: {
                              formatter: (value, context) => {
                                const sum = context.dataset.data.reduce(
                                  (a, b) => a + b,
                                  0
                                );
                                const percentage = (
                                  (value / sum) *
                                  100
                                ).toFixed(2);
                                return percentage > 0 ? percentage + "%" : "";
                              },
                              color: "#fff",
                            },
                          },
                        }}
                      />
                    </div>
                  </div>
                  <div>
                    <div className="text-center">
                      Điểm trung bình các môn thi của bạn là :{" "}
                      <span className="font-bold">{diemThi?.diemTbMon}</span>
                    </div>
                    <div className="text-center">
                      {checkDiemThiTK(
                        diemThi?.diemTbMon,
                        "khối",
                        diemThi?.slDiemThiKhoi
                      )}
                    </div>

                    <div>
                      <Doughnut
                        className="m-auto w-[400px] h-[400px] max-lg:w-[500px] max-lg:h-[500px]"
                        data={{
                          labels: diemThi?.slDiemThiKhoi?.map(
                            (value, index) => {
                              const labelName = [
                                "Giỏi",
                                "Khá",
                                "Trung Bình",
                                "Yếu",
                                "Kém",
                              ][index];
                              const percentage = (
                                (value /
                                  diemThi?.slDiemThiKhoi?.reduce(
                                    (a, b) => a + b,
                                    0
                                  )) *
                                100
                              ).toFixed(2);
                              return `${labelName} : ${value} học sinh (${percentage}%)`;
                            }
                          ),
                          datasets: [
                            {
                              label: "Số học sinh",
                              backgroundColor: [
                                "#3e95cd",
                                "#8e5ea2",
                                "#3cba9f",
                                "#e8c3b9",
                                "#c45850",
                              ],
                              data: diemThi?.slDiemThiKhoi,
                            },
                          ],
                        }}
                        options={{
                          plugins: {
                            title: {
                              display: true,
                              text: "Điểm thi trung bình môn của học sinh theo khối",
                            },
                            legend: {
                              display: true,
                              position: "bottom", // Hiển thị legend ở bên phải
                              align: "start", // Căn lề trái cho legend
                              labels: {
                                usePointStyle: true, // Sử dụng hình tròn nhỏ làm marker
                                padding: 20, // Khoảng cách giữa các dòng
                                generateLabels: function (chart) {
                                  const labels = chart.data.labels;
                                  const datasets = chart.data.datasets;
                                  return labels?.map((label, index) => ({
                                    text: label,
                                    fillStyle:
                                      datasets[0].backgroundColor[index],
                                  }));
                                },
                              },
                            },
                            datalabels: {
                              formatter: (value, context) => {
                                const sum = context.dataset.data.reduce(
                                  (a, b) => a + b,
                                  0
                                );
                                const percentage = (
                                  (value / sum) *
                                  100
                                ).toFixed(2);
                                return percentage > 0 ? percentage + "%" : "";
                              },

                              color: "#fff",
                            },
                          },
                        }}
                      />
                    </div>
                  </div>
                </div>
              ) : (
                <div className="mt-3 grid grid-cols-2">
                  <div className="p-5">
                    <div className="mt-2">
                      <span className="font-bold text-lg">
                        Biểu đồ phân tích số lượng học sinh đạt điểm thi trong
                        các khoảng điểm theo lớp
                      </span>
                    </div>
                    <div className="mt-2 text-center">
                      <span>
                        Điểm thi trung bình môn{" "}
                        {
                          listMonThi?.find((item) => item.value === monThi)
                            ?.label
                        }{" "}
                        của lớp :{" "}
                        <span className="font-bold">{diemThi?.diemTblop}</span>
                      </span>
                    </div>
                    <div className="mt-2 text-center">
                      <span>
                        Điểm thi môn{" "}
                        {
                          listMonThi?.find((item) => item.value === monThi)
                            ?.label
                        }{" "}
                        của bạn là :{" "}
                        <span className="font-bold">{diemThi?.diem}</span>
                      </span>
                    </div>
                    <div className="mt-2 m-auto">
                      <Bar
                        // className="w-[500px] h-[500px]"
                        data={{
                          labels: [
                            "0-1",
                            "1-2",
                            "2-3",
                            "3-4",
                            "4-5",
                            "5-6",
                            "6-7",
                            "7-8",
                            "8-9",
                            "9-10",
                          ],

                          datasets: [
                            {
                              label: "Số học sinh",
                              backgroundColor: ["#085BA4"],
                              data: diemThi?.slDiemTBLop || [],
                            },
                          ],
                        }}
                        options={{
                          plugins: {
                            legend: { display: false },
                            title: {
                              display: true,
                              text: `Biểu đồ lượng học sinh đạt điểm thi môn ${listMonThi?.find(
                                (item) => item.value === monThi
                              )?.label
                                } trong các khoảng điểm của lớp`,
                            },
                            datalabels: {
                              color: "#fff",
                            },
                          },
                          scales: {
                            x: {
                              title: {
                                display: true,
                                text: "Khoảng điểm",
                                position: "top",
                                font: "bold",
                                align: "end",
                              },
                            },
                            y: {
                              title: {
                                display: true,
                                text: "Học sinh",
                                position: "top",
                                align: "end",
                              },
                            },
                          },
                        }}
                      />
                    </div>
                  </div>

                  <div className="p-5">
                    <div className="mt-2">
                      <span className="font-bold text-lg">
                        Biểu đồ phân tích số lượng học sinh đạt điểm thi trong
                        các khoảng điểm theo khối
                      </span>
                    </div>
                    <div className="mt-2 text-center">
                      <span>
                        Điểm thi trung bình môn{" "}
                        {
                          listMonThi?.find((item) => item.value === monThi)
                            ?.label
                        }{" "}
                        của khối :{" "}
                        <span className="font-bold">{diemThi?.diemTbKhoi}</span>
                      </span>
                    </div>
                    <div className="mt-2 text-center">
                      <span>
                        Điểm thi môn{" "}
                        {
                          listMonThi?.find((item) => item.value === monThi)
                            ?.label
                        }{" "}
                        của bạn là :{" "}
                        <span className="font-bold">{diemThi?.diem}</span>
                      </span>
                    </div>
                    <div className="mt-2 m-auto ">
                      <Bar
                        // className="w-[500px] h-[500px]"
                        data={{
                          labels: [
                            "0-1",
                            "1-2",
                            "2-3",
                            "3-4",
                            "4-5",
                            "5-6",
                            "6-7",
                            "7-8",
                            "8-9",
                            "9-10",
                          ],

                          datasets: [
                            {
                              label: "Số học sinh",
                              backgroundColor: ["#085BA4"],
                              data: diemThi?.slDiemTBKhoi || [],
                            },
                          ],
                        }}
                        options={{
                          plugins: {
                            legend: { display: false },
                            title: {
                              display: true,
                              text: `Biểu đồ lượng học sinh đạt điểm thi môn ${listMonThi?.find(
                                (item) => item.value === monThi
                              )?.label
                                } trong các khoảng điểm của khối`,
                            },
                            datalabels: {
                              color: "#fff",
                            },
                          },
                          scales: {
                            x: {
                              title: {
                                display: true,
                                text: "Khoảng điểm",
                                position: "top",
                                font: "bold",
                                align: "end",
                              },
                            },
                            y: {
                              title: {
                                display: true,
                                text: "Học sinh",
                                position: "top",
                                align: "end",
                              },
                            },
                          },
                        }}
                      />
                    </div>
                  </div>
                </div>
              )
            ) : (
              <div>
                <div className="mt-5 text-center">
                  <span className="font-bold">{diemThi?.messageError}</span>
                </div>
              </div>
            )}
          </div>
        )}

        {/* {
                diemThi ? (
                    typeSearch === 0 ? (<>
                        <table className='w-full table-diem'>
                            <thead >
                                <tr>
                                    <th>STT</th>
                                    <th>Môn học</th>
                                    <th>Điểm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Toán</td>
                                    <td>{diemThi?.diemthi?.diemMonToan}</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>Ngữ văn</td>
                                    <td>{diemThi?.diemthi?.diemMonVan}</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>Ngoại ngữ</td>
                                    <td>{diemThi?.diemthi?.diemNgoaiNgu}</td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>Vật lý</td>
                                    <td>{diemThi?.diemthi?.diemVatLy}</td>
                                </tr>

                                <tr>
                                    <td>5</td>
                                    <td>Hóa học</td>
                                    <td>{diemThi?.diemthi?.diemHoaHoc}</td>
                                </tr>


                                <tr>
                                    <td>6</td>
                                    <td>Sinh học</td>
                                    <td>{diemThi?.diemthi?.diemSinhHoc}</td>
                                </tr>
                            </tbody>
                        </table>
                    </>) : (<>
                        <div>
                            <TableComponent
                                className="mt-3"
                                ColumnConfig={DIEM_THI_LOP}
                                DataSource={diemThi?.lstDiemThi}
                                CurrentPage={pageNumber}
                                CurrentPageSize={pageSize}
                                OnPageChange={(pageNumber, pageSize) => {
                                    dispatch(
                                        setAdvanceSearchDiemThi({
                                            pageNumber: pageNumber,
                                            pageSize: pageSize,
                                        })
                                    );
                                }}
                            />
                        </div>
                    </>)
                ) : (
                    <div className="font-bold mt-5 text-center text-xl">{errorMessage}</div>
                )

            } */}
      </div>
    </div>
  );
}
