#pragma checksum "C:\Code\Quiz\Quiz\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "505a4bdda0ec4136c151e9a5b6663516545c01d9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Quiz.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Code\Quiz\Quiz\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Code\Quiz\Quiz\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Code\Quiz\Quiz\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Code\Quiz\Quiz\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Code\Quiz\Quiz\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Code\Quiz\Quiz\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Code\Quiz\Quiz\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Code\Quiz\Quiz\_Imports.razor"
using Quiz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Code\Quiz\Quiz\_Imports.razor"
using Quiz.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Code\Quiz\Quiz\Pages\FetchData.razor"
using Quiz.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/quiz")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "C:\Code\Quiz\Quiz\Pages\FetchData.razor"
       
    private Models.Quiz quiz;

    protected override async Task OnInitializedAsync()
    {
        quiz = await QuizGenerationService.GetQuizAsync(new Models.QuizOptions
        {
            Category = (9, "A"),
            NumQuestions = 10,
            Difficulty = "easy"
        });
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IQuizGenerationService QuizGenerationService { get; set; }
    }
}
#pragma warning restore 1591
