$(function () {
    var l = abp.localization.getResource('AuctionAppResource');

    var dataTable = $('#ItemsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(collectionArt.auctionApp.services.items.item.getList),
            columnDefs: [
                {
                    title: l('OwnerId'),
                    data: "ownerId"
                },
                {
                    title: l('FirstOwnerId'),
                    data: "firstOwnerId"
                },
                {
                    title: l('Title'),
                    data: "title"
                }
                ,
                {
                    title: l('Description'),
                    data: "description"
                }
            ]
        })
    );
});
