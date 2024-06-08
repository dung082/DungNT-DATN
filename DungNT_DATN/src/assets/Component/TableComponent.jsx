import { Empty, Table } from "antd";
import React, { useEffect, useState } from "react";
import { LIST_PAGESIZE } from "../../templates/systemSetting";
import _ from "lodash";
/*
 * 1. Hàm xử lý on select row
 * 2. Hàm xử lý on checkbox
 * 3. Column config
 * 4. data source
 * 5. rowKey
 * 6. totalItem
 */
export default function TableComponent(props) {
  const {
    ColumnConfig,
    DataSource,
    RowKey,
    TotalItem,
    OnPageChange,
    HasCheckBox,
    CurrentPage,
    CurrentPageSize,
    ShowSizeChanger,
    hidePagination,
    ...rest
  } = props;

  function onPageChange(pageNumber, pageSize) {
    OnPageChange(pageNumber, pageSize);
  }

  const rowSelection = {
    onChange: (selectedRowKeys, selectedRows) => {
      props.OnRowSelected(selectedRowKeys, selectedRows);
    },
    getCheckboxProps: (record) => ({
      name: record.name,
    }),
    selectedRowKeys: props.SelectedRowKeys,
  };

  const setIndex = (dataSource, pageNumber, pageSize) => {
    // tiền xử lý => groupBy key tránh phần tử bị lặp
    const uniqDataSource = _.uniqBy(dataSource, RowKey);
    // _.uniqBy(data, 'id');
    if (pageNumber > 0) {
      pageNumber -= 1;
    }

    return uniqDataSource
      ? uniqDataSource.map((item, index) => {
          return {
            ...item,
            stt: pageNumber * pageSize + index + 1,
          };
        })
      : [];
  };

  const [currentSource, setCurrentSource] = useState([]);
  const [renderColumn, setRenderColumn] = useState(ColumnConfig);

  useEffect(() => {
    let newSource = setIndex(DataSource, CurrentPage, CurrentPageSize);
    setCurrentSource(newSource);
  }, [DataSource]);


  return (
    <>
      {HasCheckBox ? (
        <div style={{ overflow: "hidden", borderRadius: 10 }}>
          <Table
            rowSelection={{
              type: "checkbox",
              ...rowSelection,
            }}
            columns={renderColumn}
            // dataSource={DataSource}
            dataSource={currentSource}
            // dataSource={}
            rowKey={RowKey}
            pagination={
              hidePagination
                ? false
                : {
                    total: TotalItem,
                    defaultPageSize: LIST_PAGESIZE[0],
                    showSizeChanger:
                      ShowSizeChanger !== undefined ? ShowSizeChanger : true,
                    defaultCurrent: 1,
                    locale: { items_per_page: "/ trang" },
                    pageSizeOptions: LIST_PAGESIZE,
                    onChange: onPageChange,
                    // size: "small",
                    // showTotal: () => {
                    //   return Tổng số ${TotalItem} bản ghi;
                    // },
                    current: CurrentPage,
                    pageSize: CurrentPageSize,
                  }
            }
            locale={{
              emptyText: (
                <div
                  style={{ minHeight: 400 }}
                  className="d-flex align-items-center justify-content-center"
                >
                  <Empty
                    className="py-5"
                    image={Empty.PRESENTED_IMAGE_SIMPLE}
                    description="Không tìm thấy kết quả"
                  />
                </div>
              ),
            }}
            scroll={{ y: CurrentPageSize >= 20 ? 500 : null, x: 500 }}
            // scroll={{ y: 200 }}
            {...rest}
          />
        </div>
      ) : (
        <div style={{ overflow: "hidden", borderRadius: 10 }}>
          <Table
            columns={renderColumn}
            // dataSource={DataSource}
            dataSource={currentSource}
            rowKey={RowKey}
            locale={{
              emptyText: (
                <div
                  style={{ minHeight: 400 }}
                  className="d-flex align-items-center justify-content-center"
                >
                  <Empty
                    className="py-5"
                    image={Empty.PRESENTED_IMAGE_SIMPLE}
                    description="Không tìm thấy kết quả"
                  />
                </div>
              ),
            }}
            pagination={
              hidePagination
                ? false
                : {
                    total: TotalItem,
                    defaultPageSize: LIST_PAGESIZE[0],
                    showSizeChanger:
                      ShowSizeChanger !== undefined ? ShowSizeChanger : true,
                    defaultCurrent: 1,
                    locale: { items_per_page: "/ trang" },
                    pageSizeOptions: LIST_PAGESIZE,
                    onChange: onPageChange,
                    current: CurrentPage,
                    pageSize: CurrentPageSize,
                    // size: "small",
                    // showTotal: () => {
                    //   return Tổng số ${TotalItem} bản ghi;
                    // },
                  }
            }
            scroll={{
              y: CurrentPageSize >= 20 ? "50vh" : null,
              x: props.Scroll ? 1000 : null,
            }}
            // scroll={{ y: 200 }}
            // onRow={(record, rowIndex) => {
            //   return {
            //     onClick: (event) => {
            //       props.OnRowClick(record);
            //     }, // click row
            //   };
            // }}
            onChange={(pagination, filters, sorter) => {}}
            {...rest}
          />
        </div>
      )}
    </>
  );
}
