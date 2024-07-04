import dayjs from "dayjs";

export const CHUONG_TRINH_KHUNG_TABLE_CONFIG = [
  {
    title: "STT",
    dataIndex: "stt",
    key: "stt",
  },
  {
    title: "Mã môn học",
    dataIndex: "maMonHoc",
    key: "maMonHoc",
  },
  {
    title: "Tên môn học",
    dataIndex: "tenMonHoc",
    key: "tenMonHoc",
  },
  {
    title: "Tên khối học",
    dataIndex: "tenKhoi",
    key: "tenKhoi",
  },
  {
    title: "Số tiết học",
    dataIndex: "soTietHoc",
    key: "soTietHoc",
  },
];

export const CHI_TIET_LOP_HOC_COLUMN_CONFIG = [
  {
    title: "STT",
    dataIndex: "stt",
    key: "stt",
  },
  {
    title: "Họ và tên",
    dataIndex: "hoTen",
    key: "hoTen",
  },
  {
    title: "Giới tính",
    dataIndex: "gioiTinh",
    key: "gioiTinh",
    render: (_, record) => {
      if (record.gioiTinh === 1) {
        return "Nữ";
      } else {
        return "Nam";
      }
    },
  },
  {
    title: "Ngày sinh",
    dataIndex: "ngaySinh",
    key: "ngaySinh",
    render: (_, record) => {
      try {
        return dayjs(record.ngaySinh).format("DD/MM/YYYY");
      } catch (err) {
        return record.ngaySinh;
      }
    },
  },
  {
    title: "Địa chỉ",
    dataIndex: "diaChi",
    key: "diaChi",
  },
];

export const DIEM_THI_LOP = [
  {
    title: "STT",
    dataIndex: "stt",
    key: "stt",
  },
  {
    title: "Họ và tên",
    dataIndex: "hoTen",
    key: "hoTen",
  },

  {
    title: "Điểm toán",
    dataIndex: "diemMonToan",
    key: "diemMonToan",
  },

  {
    title: "Điểm văn",
    dataIndex: "diemMonVan",
    key: "diemMonVan",
  },

  {
    title: "Điểm ngoại ngữ",
    dataIndex: "diemNgoaiNgu",
    key: "diemNgoaiNgu",
  },

  {
    title: "Điểm vật lý",
    dataIndex: "diemVatLy",
    key: "diemVatLy",
  },

  {
    title: "Điểm hóa học",
    dataIndex: "diemHoaHoc",
    key: "diemHoaHoc",
  },

  {
    title: "Điểm sinh học",
    dataIndex: "diemSinhHoc",
    key: "diemSinhHoc",
  },
]