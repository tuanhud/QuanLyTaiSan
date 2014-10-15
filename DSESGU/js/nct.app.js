(function($, window) {
    var $scrollElem = $('html, body'),
        $win = $(window),
        isIE6 = !-[1, ] && !window.XMLHttpRequest,
        isMac = window.navigator.platform.toLowerCase().indexOf('mac') > -1;

    var NCTApp = function(options) {
        this.init.call(this, options);
    };

    NCTApp.prototype = {
        init: function(options) {
            this.curIndex = 0;
            this.wrapper = options.wrapper;
            this.pages = this.wrapper.find('section');
            this.pageCount = this.pages.length;
            this.scrollTop = 0;
            this.isScroll = false;
            this.time = null;
            this._bindEvent();
        },

        _bindEvent: function() {
            var self = this;
            if (window.addEventListener) {
                window.addEventListener('DOMMouseScroll', function(event) {
                    self.scroll.call(self, event)
                }, false);
                window.addEventListener('mousewheel', function(event) {
                    self.scroll.call(self, event);
                }, false);
                window.addEventListener('MozMousePixelScroll', function(event) {
                    event.preventDefault();
                }, false);
            } else {
                document.onmousewheel = function() {
                    self.scroll.call(self);
                };
            }

            var topDelta = isIE6 ? 0 : 50,
                animateName = isMac ? 'mac' : 'pc';

            var animateFn = {
                mac: function(scrollTop) {
                    $scrollElem.animate({
                        scrollTop: scrollTop
                    }, 1000, function() {
                        setTimeout(function() {
                            self.isScroll = false;
                        }, 500);
                    });
                },
                pc: function(scrollTop) {
                    $scrollElem.animate({
                        scrollTop: scrollTop
                    }, function() {
                        self.isScroll = false;
                    });
                }
            };
            this.wrapper.on('changepage', function(event, data) {
                var $nextPage = self.pages.eq(data.nextIndex);
                self.pages.eq(data.prevIndex).trigger('exit');
                $nextPage.trigger('enter');
                self.scrollTop = data.nextIndex === 0 ? 0 : $nextPage.offset().top;
                self.scrollTop -= topDelta;
                animateFn[animateName](self.scrollTop + 50);
            });

            self.pages.on('enter', function() {
                var $this = $(this);
                self.onEnter($this);
            });
            self.pages.on('exit', function() {
                var $this = $(this);
                self.onExit($this);
            });
        },
        scroll: function(event) {
            var oEvent = event || window.event;
            if (oEvent.preventDefault) {
                oEvent.preventDefault();
            } else {
                oEvent.returnValue = false;
            }
            if (this.isScroll) {
                return;
            }
            this.isScroll = true;

            var self = this,
                delta = oEvent.wheelDelta ? oEvent.wheelDelta : -oEvent.detail;
            var curIndex = 0;
            if (delta < 0) {
                curIndex = Math.min((self.curIndex + 1), self.pageCount - 1);
            } else {
                curIndex = Math.max((self.curIndex - 1), 0);
            }

            self.setIndex(curIndex);
        },
        onEnter: function($dom) {
            $dom.addClass('animate-enter').removeClass('animate-exit');
        },
        onExit: function($dom) {
          	//$dom.removeClass('animate-enter').addClass('animate-exit');
        },

        setIndex: function(index) {
            var prevIndex = this.curIndex;
            this.curIndex = index;
            this.wrapper.trigger('changepage', {
                prevIndex: prevIndex,
                nextIndex: index
            });
        }
    };

    var NCTApp = new NCTApp({
        wrapper: $('body')
    });

	var scrolltotopgroup={
	//startline: Integer. Number of pixels from top of doc scrollbar is scrolled before showing control
	//scrollto: Keyword (Integer, or "Scroll_to_Element_ID"). How far to scroll document up when control is clicked on (0=top).
	setting: {startline:100, scrollto: 0, scrollduration:1000, fadeduration:[500, 100]},
	controlHTML: '<img src="images/toppage.png" style="width:32px; height:32px" />', //HTML for control, which is auto wrapped in DIV w/ ID="topcontrol"
	controlattrs: {offsetx:10, offsety:10}, //offset of control relative to right/ bottom of window corner
	anchorkeyword: '#toppage', //Enter href value of HTML anchors on the page that should also act as "Scroll Up" links

	state: {isvisible:false, shouldvisible:false},

	scrollup:function(){
NCTApp.setIndex(0);
		if (!this.cssfixedsupport) //if control is positioned using JavaScript
			this.$control.css({opacity:0}) //hide control immediately after clicking it
		var dest=isNaN(this.setting.scrollto)? this.setting.scrollto : parseInt(this.setting.scrollto)
		if (typeof dest=="string" && jQuery('#'+dest).length==1) //check element set by string exists
			dest=jQuery('#'+dest).offset().top
		else
			dest=0
		this.$body.animate({scrollTop: dest}, this.setting.scrollduration);
	},

	keepfixed:function(){
		var $window=jQuery(window)
		var controlx=$window.scrollLeft() + $window.width() - this.$control.width() - this.controlattrs.offsetx
		var controly=$window.scrollTop() + $window.height() - this.$control.height() - this.controlattrs.offsety
		this.$control.css({left:controlx+'px', top:controly+'px'})
	},

	togglecontrol:function(){
		var scrolltop=jQuery(window).scrollTop()
		if (!this.cssfixedsupport)
			this.keepfixed()
		this.state.shouldvisible=(scrolltop>=this.setting.startline)? true : false
		if (this.state.shouldvisible && !this.state.isvisible){
			this.$control.stop().animate({opacity:1}, this.setting.fadeduration[0])
			this.state.isvisible=true
		}
		else if (this.state.shouldvisible==false && this.state.isvisible){
			this.$control.stop().animate({opacity:0}, this.setting.fadeduration[1])
			this.state.isvisible=false
		}
	},
	
	init:function(){
		jQuery(document).ready(function($){
			var mainobj=scrolltotopgroup
			var iebrws=document.all
			mainobj.cssfixedsupport=!iebrws || iebrws && document.compatMode=="CSS1Compat" && window.XMLHttpRequest //not IE or IE7+ browsers in standards mode
			mainobj.$body=(window.opera)? (document.compatMode=="CSS1Compat"? $('html') : $('body')) : $('html,body')
			mainobj.$control=$('<div id="topcontrol" class="right_box_toppage"><div class="goTopPage hover"><a onclick="backtotop();">&nbsp;</a></div></div>')
				.css({position:mainobj.cssfixedsupport? 'fixed' : 'absolute', bottom:90, right:mainobj.controlattrs.offsetx, opacity:0, cursor:'pointer'})
				.attr({title:''})
				.click(function(){mainobj.scrollup(); return false})
				.appendTo('body')
			if (document.all && !window.XMLHttpRequest && mainobj.$control.text()!='') //loose check for IE6 and below, plus whether control contains any text
				mainobj.$control.css({width:mainobj.$control.width()}) //IE6- seems to require an explicit width on a DIV containing text
			mainobj.togglecontrol()
			$('a[href="' + mainobj.anchorkeyword +'"]').click(function(){
				mainobj.scrollup()
				return false
			})
			$(window).bind('scroll resize', function(e){
				mainobj.togglecontrol()
			});
		})
	}
};
scrolltotopgroup.init()
})(jQuery, window);
