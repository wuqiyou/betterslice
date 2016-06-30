using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slice.Web.Models;

namespace Slice.Web.Test.Models
{
    [TestClass]
    public class PaginationViewModelFixture
    {
        private string PagingQueryStringParameter { get; set; }
        private int PageSize { get; set; }
        private int PagerWindowSize { get; set; }
        private Uri Url { get; set; }

        [TestInitialize]
        public void Setup()
        {
            this.PageSize = 10;
            this.PagerWindowSize = 5;
            this.Url = new Uri("http://test.com/search/?q=test");
            this.PagingQueryStringParameter = "pn";
        }

        [TestMethod]
        public void TotalItemsIsExactlyMultipleOfPageSize()
        {
            int totalItems = 90;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(9, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(5, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(2, vm.NextPage);
        }

        [TestMethod]
        public void TotalItemsIsNotExactlyMultipleOfPageSize1()
        {
            int totalItems = 91;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(5, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(2, vm.NextPage);
        }

        [TestMethod]
        public void TotalItemsIsNotExactlyMultipleOfPageSize2()
        {
            int totalItems = 89;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(9, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(5, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(2, vm.NextPage);
        }

        [TestMethod]
        public void OnlyOnePage_ShouldReturnBoundariesAsOne()
        {
            int totalItems = 8;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(1, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(1, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(1, vm.NextPage);
        }

        [TestMethod]
        public void OnlyTwoPages_ShouldReturnBoundariesBetweenOneAndTwo()
        {
            int totalItems = 18;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(2, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(2, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(2, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithLeftEndEdgeIndex1()
        {
            int totalItems = 91;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(5, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(2, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithLeftEndEdgeIndex2()
        {
            int totalItems = 91;
            int currentPage = 2;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(5, vm.UpperBoundary);
            Assert.AreEqual(1, vm.PreviousPage);
            Assert.AreEqual(3, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithLeftEndEdgeIndex3()
        {
            int totalItems = 91;
            int currentPage = 3;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(5, vm.UpperBoundary);
            Assert.AreEqual(2, vm.PreviousPage);
            Assert.AreEqual(4, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithRightEndEdgeIndex1()
        {
            int totalItems = 91;
            int currentPage = 10;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(6, vm.LowerBoundary);
            Assert.AreEqual(10, vm.UpperBoundary);
            Assert.AreEqual(9, vm.PreviousPage);
            Assert.AreEqual(10, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithRightEndEdgeIndex2()
        {
            int totalItems = 91;
            int currentPage = 9;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(6, vm.LowerBoundary);
            Assert.AreEqual(10, vm.UpperBoundary);
            Assert.AreEqual(8, vm.PreviousPage);
            Assert.AreEqual(10, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithRightEndEdgeIndex3()
        {
            int totalItems = 91;
            int currentPage = 8;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(6, vm.LowerBoundary);
            Assert.AreEqual(10, vm.UpperBoundary);
            Assert.AreEqual(7, vm.PreviousPage);
            Assert.AreEqual(9, vm.NextPage);
        }

        [TestMethod]
        public void MultipagesWithMiddleRangeIndex()
        {
            int totalItems = 91;
            int currentPage = 5;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(10, vm.MaxPage);
            Assert.AreEqual(3, vm.LowerBoundary);
            Assert.AreEqual(7, vm.UpperBoundary);
            Assert.AreEqual(4, vm.PreviousPage);
            Assert.AreEqual(6, vm.NextPage);
        }

        [TestMethod]
        public void GetPageUrlByPageIndex_ShouldReturnCorrectPageUrl()
        {
            int totalItems = 91;
            int currentPage = 5;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            string url1 = vm.GetPageUrl(1, this.Url, this.PagingQueryStringParameter);
            Assert.AreEqual("/search/?q=test&pn=1", url1);

            string url2 = vm.GetPageUrl(2, this.Url, this.PagingQueryStringParameter);
            Assert.AreEqual("/search/?q=test&pn=2", url2);
        }

        [TestMethod]
        public void OnlyOnePage_ShouldBeSuppressed()
        {
            int totalItems = 8;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(true, vm.IsSuppressed);
        }

        [TestMethod]
        public void MoreThanOnePage_ShouldNotBeSuppressed()
        {
            int totalItems = 18;
            int currentPage = 1;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(false, vm.IsSuppressed);
        }

        [TestMethod]
        public void LessThan5PagesAndLandingOnLastPage()
        {
            int totalItems = 34;
            int currentPage = 4;

            PaginationViewModel vm = new PaginationViewModel(totalItems, currentPage);

            Assert.AreEqual(4, vm.MaxPage);
            Assert.AreEqual(1, vm.LowerBoundary);
            Assert.AreEqual(4, vm.UpperBoundary);
            Assert.AreEqual(3, vm.PreviousPage);
            Assert.AreEqual(4, vm.NextPage);
        }
    }
}
