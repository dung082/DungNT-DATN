import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { globalState } from '../../../reducers/globalReducer/globalReducer'
import { diemThiState, getDiemThiAction, getListMonThiAction, setAdvanceSearchDiemThi, setKyThi, setMonThi, setNamHoc, setTypeSearch } from '../../../reducers/diemThiReducer/diemThiReducer'
import { Button, Select } from 'antd'
import dayjs from 'dayjs'
import { getListKyThiAction, kyThiState } from '../../../reducers/kyThiReducer/kyThiReducer'
import TableComponent from '../../../assets/Component/TableComponent'
import { DIEM_THI_LOP } from '../../../templates/tableConfig'
import { Doughnut } from 'react-chartjs-2'
import { Chart as ChartJs } from 'chart.js'
export default function DiemThi(props) {

    const dispatch = useDispatch()
    const { userInfo } = useSelector(globalState)
    const { diemThi, pageNumber, pageSize, typeSearch, kyThi, namHoc, errorMessage, listMonThi, monThi } = useSelector(diemThiState)
    const { listKyThi } = useSelector(kyThiState)
    const listTypeSearch = [{
        label: "Cá nhân",
        value: 0
    }, {
        label: "Lớp",
        value: 1
    }]

    const listNamHoc = [{
        label: "2022-2023",
        value: "2022-2023"
    }, {
        label: "2023-2024",
        value: "2023-2024"
    },
    {
        label: "2024-2025",
        value: "2024-2025"
    }]



    useEffect(() => {
        dispatch(getListKyThiAction(""))
        dispatch(getDiemThiAction(userInfo?.username, "", ""))
        dispatch(getListMonThiAction(userInfo?.lopIdHienTai))
        return () => {
            dispatch(setTypeSearch(0))
        }
    }, [])
    // const

    return (<div>
        <div className="p-5">
            <div className=" bottem-border-title pb-2">
                <div className="flex justify-between">
                    <div>
                        <span className="font-bold text-xl">
                            Xem điểm thi
                        </span>
                    </div>
                </div>
            </div>

            {
                kyThi === "" ? (
                    <div>
                        <Doughnut
                            data={{
                                labels: [
                                    "Kém",
                                    "Yếu",
                                    "Trung Bình",
                                    "Khá",
                                    "Giỏi"
                                ],
                                datasets: [
                                    {
                                        label: "Population (millions)",
                                        backgroundColor: [
                                            "#3e95cd",
                                            "#8e5ea2",
                                            "#3cba9f",
                                            "#e8c3b9",
                                            "#c45850"
                                        ],
                                        data: diemThi?.slDiemThiLop
                                    }
                                ]
                            }}
                            option={{
                                title: {
                                    display: true,
                                    text: "Predicted world population (millions) in 2050"
                                }
                            }}
                        />
                    </div>
                ) : (<div>
                    <div>

                    </div>
                </div>)
            }
            {/* <div className="flex items-end justify-center">
                <div className='w-[1000px] grid grid-cols-4'>
                    <div className="p-2">
                        <span>
                            Năm học
                        </span>
                        <Select
                            placeholder="Chọn kỳ học"
                            className='w-full'
                            options={listNamHoc}
                            value={namHoc}
                            onChange={(e) => {
                                dispatch(setNamHoc(e))
                                dispatch(getListKyThiAction(e))
                                dispatch(setKyThi(null))
                            }}
                        // value={namHocSelect}
                        />
                    </div>

                    <div className="p-2">
                        <span>
                            Môn thi
                        </span>
                        <Select
                            placeholder="Chọn môn thi"
                            className='w-full'
                            options={listKyThi}
                            value={kyThi}
                            onChange={(e) => {
                                dispatch(setKyThi(e))
                            }}
                        />
                    </div>

                    <div className="p-2">
                        <span>
                            Kỳ thi
                        </span>
                        <Select
                            placeholder="Chọn kỳ thi"
                            className='w-full'
                            options={listMonThi}
                            value={monThi}
                            onChange={(e) => {
                                dispatch(setMonThi(e))
                            }}
                        />
                    </div>

                    <div className="p-2 flex items-end">
                        <Button type="primary" onClick={() => {
                            dispatch(getDiemThiAction(userInfo?.username, kyThi, monThi))
                        }}>Tra cứu</Button>
                    </div>
                </div>
            </div>
            {
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
        </div >
    </div >)
}