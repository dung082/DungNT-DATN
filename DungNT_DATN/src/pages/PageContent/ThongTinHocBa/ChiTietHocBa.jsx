import { Input, Select } from 'antd'
import React, { useEffect } from 'react'
export default function ChiTietHocBa(props) {
    const { hocba } = props

    const hanhKiem = [
        {
            value: 1,
            label: "Tốt",
        },
        {
            value: 2,
            label: "Khá",
        },
        {
            value: 3,
            label: "Trung bình",
        },
        {
            value: 4,
            label: "Yếu",
        },
    ]

    const hocluc = [
        {
            value: 1,
            label: "Giỏi",
        },
        {
            value: 2,
            label: "Khá",
        },
        {
            value: 3,
            label: "Trung bình",
        },
        {
            value: 4,
            label: "Yếu",
        },
        {
            value: 5,
            label: "Chưa thể loại",
        },
    ]
    return (
        <>
            {
                hocba?.hocBa !== "" ?
                    (<>
                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>1.Điểm tổng kết</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.diemTKHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.diemTKHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.diemTKCN} />
                                </div>
                            </div>
                        </div>


                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>2.Học lực</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Select disabled value={hocba?.hocBa?.hocLucHK1} options={hocluc} className="w-full" />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Select disabled value={hocba?.hocBa?.hocLucHK2} options={hocluc} className="w-full" />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Select disabled value={hocba?.hocBa?.hocLucCN} options={hocluc} className="w-full" />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>3.Hạnh kiểm</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Select disabled value={hocba?.hocBa?.diemHKHK1} options={hanhKiem} className='w-full' />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Select disabled value={hocba?.hocBa?.diemHKHK2} options={hanhKiem} className='w-full' />

                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Select disabled value={hocba?.hocBa?.diemHKCN} options={hanhKiem} className='w-full' />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>4.Toán</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.diemToanHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.diemToanHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.diemToanCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>5.Ngữ văn</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.diemVanHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.diemVanHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.diemVanCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>6.Vật lý</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.diemLyHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.diemLyHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.diemLyCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>7.Hóa học</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.diemHoaHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.diemHoaHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.diemHoaCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>8.Sinh học</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.sinhHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.sinhHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.sinhCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>9.Lịch sử</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.lichSuHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.lichSuHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.lichSuCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>10.Địa lí</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.diaHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.diaHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.diaCN} />
                                </div>
                            </div>
                        </div>

                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>11.Giáo dục công dân</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.gdcdhK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.gdcdhK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.gdcdcn} />
                                </div>
                            </div>
                        </div>


                        <div className="mt-2">
                            <div className="px-2">
                                <span className='font-bold'>12.Ngoại ngữ</span>
                            </div>
                            <div className="grid grid-cols-3">
                                <div className="p-2">
                                    <span>Học kỳ I</span>
                                    <Input disabled value={hocba?.hocBa?.ngoaiNguHK1} />
                                </div>
                                <div className="p-2">
                                    <span>Học kỳ II</span>
                                    <Input disabled value={hocba?.hocBa?.ngoaiNguHK2} />
                                </div>
                                <div className="p-2">
                                    <span>Cả năm</span>
                                    <Input disabled value={hocba?.hocBa?.ngoaiNguCN} />
                                </div>
                            </div>
                        </div>
                    </>
                    ) :
                    (<div className="font-bold text-xl mt-3 text-center">
                        <span>{hocba?.title}</span>
                    </div>)
            }

        </>
    )
}